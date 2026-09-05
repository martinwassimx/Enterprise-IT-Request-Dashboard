/**
 * NSF Employee Management - Connected to C# Web API
 * Endpoints: api/Employee/GetByNationalID, GetLatestSerial, SaveEmp, UpdateEmp, DeleteEmp
 */

document.addEventListener('DOMContentLoaded', () => {
  // AUTH CHECK
  const accessToken = sessionStorage.getItem('nsf_access_token');
  const username = sessionStorage.getItem('nsf_username') || 'User';
  const activeServerBase = sessionStorage.getItem('nsf_server_base') || 'https://localhost:44372';

  if (!accessToken) { window.location.href = 'index.html'; return; }

  // Theme
  const savedTheme = localStorage.getItem('nsf_theme') || 'light';
  document.documentElement.setAttribute('data-theme', savedTheme);

  // Display user
  document.getElementById('loggedInUserName').textContent = username;
  const nameParts = username.split(' ');
  document.getElementById('userAvatar').textContent = nameParts.map(p => p[0]).join('').toUpperCase().slice(0, 2);

  // Theme toggle
  document.getElementById('themeToggleBtn').addEventListener('click', () => {
    const current = document.documentElement.getAttribute('data-theme');
    const next = current === 'light' ? 'dark' : 'light';
    document.documentElement.setAttribute('data-theme', next);
    localStorage.setItem('nsf_theme', next);
  });

  // Logout
  document.getElementById('btnLogout').addEventListener('click', () => {
    sessionStorage.clear();
    window.location.href = 'index.html';
  });

  // Elements
  const searchNationalID = document.getElementById('searchNationalID');
  const btnSearch = document.getElementById('btnSearch');
  const btnRefresh = document.getElementById('btnRefresh');
  const btnAddEmp = document.getElementById('btnAddEmp');
  const btnUpdateEmp = document.getElementById('btnUpdateEmp');
  const btnDeleteEmp = document.getElementById('btnDeleteEmp');

  // Form fields
  const empEID = document.getElementById('empEID');
  const empFirstName = document.getElementById('empFirstName');
  const empSecondName = document.getElementById('empSecondName');
  const empNationalID = document.getElementById('empNationalID');
  const empPhoneNumber = document.getElementById('empPhoneNumber');
  const empAddress = document.getElementById('empAddress');
  const empTitle = document.getElementById('empTitle');
  const empSerial = document.getElementById('empSerial');
  const empMail = document.getElementById('empMail');
  const empBirthDate = document.getElementById('empBirthDate');

  // Track state to prevent double submissions and mode
  let isSubmitting = false;
  let isEditMode = false; // true when a searched employee is loaded

  function getAuthHeaders() {
    return {
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${accessToken}`
    };
  }

  // -------------------------------------------------------
  // FETCH NEXT SERIAL (auto-generated, readonly)
  // -------------------------------------------------------
  async function fetchNextSerial() {
    try {
      const res = await fetch(`${activeServerBase}/api/Employee/GetLatestSerial/`, {
        headers: getAuthHeaders()
      });

      if (res.ok) {
        const data = await res.json();
        empSerial.value = data.NextSerial || 'N001';
      }
    } catch (err) {
      console.warn('GetLatestSerial error:', err);
      empSerial.value = 'N001';
    }
  }

  // -------------------------------------------------------
  // SEARCH BY NATIONAL ID
  // -------------------------------------------------------
  btnSearch.addEventListener('click', async () => {
    const natID = searchNationalID.value.trim();
    if (!natID) { showToast('Please enter a National ID to search', 'error'); return; }

    try {
      showToast('Searching...', 'info');
      const res = await fetch(`${activeServerBase}/api/Employee/GetByNationalID/?NationalID=${natID}`, {
        headers: getAuthHeaders()
      });

      if (res.ok) {
        const emp = await res.json();
        if (emp) {
          populateForm(emp);
          setEditMode(true);
          showToast(`Found: ${emp.FirstName} ${emp.SecoendName}`, 'success');
        } else {
          showToast('No employee found with that National ID', 'error');
        }
      } else {
        const errText = await res.text();
        showToast('Employee not found (الموظف غير موجود)', 'error');
      }
    } catch (err) {
      console.error('Search error:', err);
      showToast('Search failed: API connection error', 'error');
    }
  });

  // Enter key to search
  searchNationalID.addEventListener('keydown', (e) => {
    if (e.key === 'Enter') { btnSearch.click(); }
  });

  // -------------------------------------------------------
  // REFRESH - Clear form and fetch next serial
  // -------------------------------------------------------
  btnRefresh.addEventListener('click', () => {
    clearForm();
    fetchNextSerial();
    showToast('Form cleared & serial refreshed', 'info');
  });

  // -------------------------------------------------------
  // ADD NEW EMPLOYEE (POST api/Employee/SaveEmp/)
  // The API expects List<EmpData> (array) and Serial is auto by SQL
  // -------------------------------------------------------
  btnAddEmp.addEventListener('click', async () => {
    if (isSubmitting) return; // Prevent double-click
    if (isEditMode) {
      showToast('You are in edit mode. Click "Refresh" to clear form before adding a new employee.', 'error');
      return;
    }

    const empData = getFormData();
    if (!empData.FirstName || !empData.SecoendName) {
      showToast('الاسم الأول والثاني مطلوبان / First Name and Second Name are required', 'error');
      return;
    }

    // NationalID validation — distinguish empty vs incorrect format
    const natIdRaw = empNationalID.value.trim();
    if (!natIdRaw) {
      showToast('⚠️ الرقم الوطني مطلوب / National ID is required', 'error');
      empNationalID.focus();
      return;
    }
    if (isNaN(Number(natIdRaw)) || natIdRaw.includes('.') || natIdRaw.includes('e')) {
      showToast('❌ الرقم الوطني غير صحيح / National ID is incorrect — must be a valid whole number', 'error');
      empNationalID.focus();
      return;
    }
    if (empData.NationalID <= 0) {
      showToast('❌ الرقم الوطني غير صحيح / National ID must be greater than 0', 'error');
      empNationalID.focus();
      return;
    }

    isSubmitting = true;
    btnAddEmp.disabled = true;
    btnAddEmp.textContent = 'Adding...';

    try {
      showToast('Adding employee...', 'info');

      // API expects a List<EmpData> (JSON array)
      const payload = [empData];

      const res = await fetch(`${activeServerBase}/api/Employee/SaveEmp/`, {
        method: 'POST',
        headers: getAuthHeaders(),
        body: JSON.stringify(payload)
      });

      if (res.ok) {
        showToast(`Employee "${empData.FirstName} ${empData.SecoendName}" added successfully! (تم الحفظ)`, 'success');
        clearForm();
        await fetchNextSerial();
      } else {
        const errText = await res.text();
        showToast(`Add failed: ${errText}`, 'error');
      }
    } catch (err) {
      console.error('SaveEmp error:', err);
      showToast('Add failed: API connection error', 'error');
    } finally {
      isSubmitting = false;
      btnAddEmp.disabled = false;
      btnAddEmp.innerHTML = `<svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><path d="M16 21v-2a4 4 0 0 0-4-4H6a4 4 0 0 0-4 4v2"></path><circle cx="9" cy="7" r="4"></circle><line x1="19" y1="8" x2="19" y2="14"></line><line x1="22" y1="11" x2="16" y2="11"></line></svg> Add New Employee`;
    }
  });

  // -------------------------------------------------------
  // UPDATE EMPLOYEE (POST api/Employee/UpdateEmp/)
  // The API expects List<EmpData> (array)
  // -------------------------------------------------------
  btnUpdateEmp.addEventListener('click', async () => {
    if (isSubmitting) return;

    // Must be in edit mode (employee loaded via search)
    if (!isEditMode || !empEID.value) {
      showToast('⚠️ يرجى البحث عن موظف أولاً ثم التعديل / Please search for an employee first before updating', 'error');
      return;
    }

    const empData = getFormData();
    if (!empData.EID) {
      showToast('⚠️ يرجى البحث عن موظف أولاً / Please search for an employee first before updating', 'error');
      return;
    }

    isSubmitting = true;
    btnUpdateEmp.disabled = true;

    try {
      showToast('Updating employee...', 'info');

      // API expects a List<EmpData> (JSON array)
      const payload = [empData];

      const res = await fetch(`${activeServerBase}/api/Employee/UpdateEmp/`, {
        method: 'POST',
        headers: getAuthHeaders(),
        body: JSON.stringify(payload)
      });

      if (res.ok) {
        showToast(`Employee "${empData.FirstName} ${empData.SecoendName}" updated! (تم التعديل)`, 'success');
      } else {
        const errText = await res.text();
        showToast(`Update failed: ${errText}`, 'error');
      }
    } catch (err) {
      console.error('UpdateEmp error:', err);
      showToast('Update failed: API connection error', 'error');
    } finally {
      isSubmitting = false;
      btnUpdateEmp.disabled = false;
    }
  });

  // -------------------------------------------------------
  // DELETE EMPLOYEE (POST api/Employee/DeleteEmp/?EID=xxx)
  // -------------------------------------------------------
  btnDeleteEmp.addEventListener('click', async () => {
    if (isSubmitting) return;

    // Must be in edit mode (employee loaded via search)
    if (!isEditMode || !empEID.value || isNaN(parseInt(empEID.value))) {
      showToast('⚠️ يرجى البحث عن موظف أولاً ثم الحذف / Please search for an employee first, then click Delete', 'error');
      return;
    }

    const eid = empEID.value;

    const empName = `${empFirstName.value} ${empSecondName.value}`.trim();
    const confirmed = await showConfirmModal(empName, eid);
    if (!confirmed) return;

    isSubmitting = true;
    btnDeleteEmp.disabled = true;
    btnDeleteEmp.style.opacity = '0.5';
    btnDeleteEmp.textContent = 'Deleting...';

    try {
      showToast('جاري الحذف... / Deleting employee...', 'info');
      const res = await fetch(`${activeServerBase}/api/Employee/DeleteEmp/?EID=${eid}`, {
        method: 'POST',
        headers: getAuthHeaders()
      });

      if (res.ok) {
        showToast(`✅ تم حذف الموظف "${empName}" بنجاح / Employee deleted successfully!`, 'success');
        // Reset to new-employee mode after delete
        clearForm();
        setEditMode(false);
        await fetchNextSerial();
      } else {
        let errText = '';
        try { errText = await res.text(); } catch (_) { errText = `HTTP ${res.status}`; }
        // Parse JSON-wrapped error string if needed
        try { errText = JSON.parse(errText); } catch (_) { /* keep as-is */ }
        showToast(`❌ فشل الحذف / Delete failed: ${errText}`, 'error');
        // Re-enable delete since we are still in edit mode
        btnDeleteEmp.disabled = false;
        btnDeleteEmp.style.opacity = '1';
      }
    } catch (err) {
      console.error('DeleteEmp error:', err);
      showToast('❌ فشل الحذف — خطأ في الاتصال / Delete failed: API connection error', 'error');
      btnDeleteEmp.disabled = false;
      btnDeleteEmp.style.opacity = '1';
    } finally {
      isSubmitting = false;
      btnDeleteEmp.innerHTML = `<svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><polyline points="3 6 5 6 21 6"></polyline><path d="M19 6v14a2 2 0 0 1-2 2H7a2 2 0 0 1-2-2V6m3 0V4a2 2 0 0 1 2-2h4a2 2 0 0 1 2 2v2"></path></svg> Delete`;
    }
  });

  // -------------------------------------------------------
  // FORM HELPERS
  // -------------------------------------------------------
  function populateForm(emp) {
    empEID.value = emp.EID || '';
    empFirstName.value = emp.FirstName || '';
    empSecondName.value = emp.SecoendName || '';
    empNationalID.value = emp.NationalID || '';
    empPhoneNumber.value = emp.PhoneNumber || '';
    empAddress.value = emp.Address || '';
    empTitle.value = emp.Title || '';
    empSerial.value = emp.Serial || '';
    empMail.value = emp.Mail || '';

    if (emp.BirthDate) {
      const d = new Date(emp.BirthDate);
      empBirthDate.value = d.toISOString().split('T')[0];
    } else {
      empBirthDate.value = '';
    }
  }

  function getFormData() {
    // Safely parse integers - prevent NaN (which becomes null in JSON and breaks C# SQL)
    const eid = parseInt(empEID.value);
    const natId = parseInt(empNationalID.value);

    // BirthDate: send as "yyyy-MM-dd" string or today's date (C# SQL does N'yyyy-MM-dd')
    let birthDate = empBirthDate.value || null;
    if (birthDate) {
      birthDate = birthDate; // already in yyyy-MM-dd format from date input
    }

    return {
      EID: isNaN(eid) ? 0 : eid,
      FirstName: empFirstName.value.trim(),
      SecoendName: empSecondName.value.trim(),
      NationalID: isNaN(natId) ? 0 : natId,
      PhoneNumber: empPhoneNumber.value.trim(),
      Address: empAddress.value.trim(),
      Title: empTitle.value.trim(),
      Serial: empSerial.value.trim(),
      Mail: empMail.value.trim(),
      BirthDate: birthDate
    };
  }

  function clearForm() {
    empEID.value = '';
    empFirstName.value = '';
    empSecondName.value = '';
    empNationalID.value = '';
    empPhoneNumber.value = '';
    empAddress.value = '';
    empTitle.value = '';
    empSerial.value = '';
    empMail.value = '';
    empBirthDate.value = '';
    searchNationalID.value = '';
    setEditMode(false);
  }

  function setEditMode(editing) {
    isEditMode = editing;
    const eidDisplay = document.getElementById('empEIDDisplay');
    const serialDisplay = document.getElementById('empSerialDisplay');

    if (editing) {
      // Show EID and loaded serial
      // Add is blocked (employee already exists), Update/Delete are highlighted
      if (eidDisplay) eidDisplay.textContent = `EID: ${empEID.value}`;
      if (serialDisplay) serialDisplay.textContent = `Serial: ${empSerial.value}`;
      btnAddEmp.style.opacity = '0.5';
      btnUpdateEmp.style.opacity = '1';
      btnDeleteEmp.style.opacity = '1';
      btnUpdateEmp.style.boxShadow = '0 0 0 2px var(--accent, #f59e0b)';
      btnDeleteEmp.style.boxShadow = '0 0 0 2px var(--danger, #ef4444)';
    } else {
      // New mode: Add is active, Update/Delete are dimmed (but still clickable - will show toast)
      if (eidDisplay) eidDisplay.textContent = 'New Employee';
      if (serialDisplay) serialDisplay.textContent = '';
      btnAddEmp.style.opacity = '1';
      btnUpdateEmp.style.opacity = '0.4';
      btnDeleteEmp.style.opacity = '0.4';
      btnUpdateEmp.style.boxShadow = 'none';
      btnDeleteEmp.style.boxShadow = 'none';
    }
  }

  // -------------------------------------------------------
  // CUSTOM CONFIRM MODAL (replaces browser confirm())
  // -------------------------------------------------------
  function showConfirmModal(empName, eid) {
    return new Promise((resolve) => {
      const overlay    = document.getElementById('deleteConfirmOverlay');
      const badgeEl    = document.getElementById('confirmEmpBadge');
      const msgEl      = document.getElementById('confirmDeleteMsg');
      const btnConfirm = document.getElementById('confirmDeleteBtn');
      const btnCancel  = document.getElementById('confirmCancelBtn');

      // Populate content
      badgeEl.textContent = empName || `EID: ${eid}`;
      msgEl.textContent   = `هل أنت متأكد من حذف هذا الموظف؟ / Are you sure you want to permanently delete this employee?`;

      // Show modal
      overlay.classList.remove('hidden');
      document.body.style.overflow = 'hidden';

      function close(result) {
        overlay.classList.add('hidden');
        document.body.style.overflow = '';
        btnConfirm.removeEventListener('click', onConfirm);
        btnCancel.removeEventListener('click', onCancel);
        overlay.removeEventListener('click', onOverlayClick);
        resolve(result);
      }

      function onConfirm() { close(true); }
      function onCancel()  { close(false); }
      function onOverlayClick(e) { if (e.target === overlay) close(false); }

      btnConfirm.addEventListener('click', onConfirm);
      btnCancel.addEventListener('click', onCancel);
      overlay.addEventListener('click', onOverlayClick);
    });
  }

  // -------------------------------------------------------
  // UTILITIES
  // -------------------------------------------------------
  function showToast(message, type) {
    const container = document.getElementById('toastContainer');
    const toast = document.createElement('div');
    toast.className = `toast toast-${type}`;
    toast.innerHTML = message;
    container.appendChild(toast);
    setTimeout(() => { toast.style.opacity = '0'; toast.style.transform = 'translateX(100%)'; toast.style.transition = 'all 0.3s'; setTimeout(() => toast.remove(), 300); }, 3500);
  }

  // Initialize: new mode + fetch next serial
  setEditMode(false);
  fetchNextSerial();
});
