/**
 * NSF Request Page - Connected to C# Web API (api/Ticket/)
 * Auth: Bearer token from sessionStorage (set by login page)
 */

const SPEC_LOOKUPS = {
  "Hardware": ["4G ROUTER","Attendance Machine","Barcode Printer","BarCode Zebra","Desktop Workstation","Laptop MacBook Pro 16\"","Dual 4K Monitor","HP Network Printer"],
  "Service": ["Network Port Activation","VPN Gateway Access","Email Domain Configuration","System Maintenance SLA","Mobile Line Activation"],
  "Software": ["Adobe Creative Cloud License","Microsoft 365 Enterprise","Windows 11 Pro Key","SAP ERP System Access","Visual Studio Enterprise"]
};

const USER_MANAGERS = {
  "Martin Wassim": "ehab.makram",
  "Hassan Ali": "ahmed.manage",
  "Medhat Magdy": "ehab.makram"
};

document.addEventListener('DOMContentLoaded', () => {
  // AUTH CHECK
  const accessToken = sessionStorage.getItem('nsf_access_token');
  const currentUser = sessionStorage.getItem('nsf_username') || 'User';
  const activeServerBase = sessionStorage.getItem('nsf_server_base') || 'https://localhost:44372';

  if (!accessToken) { window.location.href = 'index.html'; return; }

  // Theme
  const savedTheme = localStorage.getItem('nsf_theme') || 'light';
  document.documentElement.setAttribute('data-theme', savedTheme);

  // Display user info
  document.getElementById('loggedInUserName').textContent = currentUser;
  document.getElementById('loggedInUserManager').textContent = 'Token: Active';
  const nameParts = currentUser.split(' ');
  document.getElementById('userAvatar').textContent = nameParts.map(p => p[0]).join('').toUpperCase().slice(0, 2);

  // Set User_Name and Manager from logged in user
  const userNameInput = document.getElementById('userNameInput');
  const managerInput = document.getElementById('managerInput');
  userNameInput.value = currentUser;
  userNameInput.readOnly = true;
  managerInput.value = USER_MANAGERS[currentUser] || 'ehab.makram';
  managerInput.readOnly = true;

  // Elements
  const themeToggleBtn = document.getElementById('themeToggleBtn');
  const btnLogout = document.getElementById('btnLogout');
  const tabNewRequestBtn = document.getElementById('tabNewRequestBtn');
  const tabAllTicketsBtn = document.getElementById('tabAllTicketsBtn');
  const viewNewRequest = document.getElementById('viewNewRequest');
  const viewAllTickets = document.getElementById('viewAllTickets');
  const savedTicketsCount = document.getElementById('savedTicketsCount');
  const reqTypeSelect = document.getElementById('reqType');
  const siteSelect = document.getElementById('site');
  const reqNoInput = document.getElementById('reqNo');
  const copyReqNoBtn = document.getElementById('copyReqNo');
  const radioForMe = document.getElementById('radioForMe');
  const radioOnBehalf = document.getElementById('radioOnBehalf');
  const userNameSelectWrapper = document.getElementById('userNameSelectWrapper');
  const userNameSelect = document.getElementById('userNameSelect');
  const btnCreateRequest = document.getElementById('btnCreateRequest');
  const requestDetailSection = document.getElementById('requestDetailSection');
  const lockStatusBadge = document.getElementById('lockStatusBadge');
  const reqDetailItemSelect = document.getElementById('reqDetailItem');
  const reqDetailSpecSelect = document.getElementById('reqDetailSpec');
  const switchPrivate = document.getElementById('switchPrivate');
  const privateLabel = document.getElementById('privateLabel');
  const reqOtherInput = document.getElementById('reqOther');
  const reqRemarksArea = document.getElementById('reqRemarks');
  const charCount = document.getElementById('charCount');
  const btnAddDetail = document.getElementById('btnAddDetail');
  const requestsTable = document.getElementById('requestsTable');
  const tableBody = document.getElementById('tableBody');
  const emptyState = document.getElementById('emptyState');
  const itemsCountBadge = document.getElementById('itemsCountBadge');
  const btnSave = document.getElementById('btnSave');
  const btnNew = document.getElementById('btnNew');
  const allTicketsTableBody = document.getElementById('allTicketsTableBody');
  const allTicketsEmptyState = document.getElementById('allTicketsEmptyState');
  const btnRefreshTickets = document.getElementById('btnRefreshTickets');

  let isRequestCreated = false;

  function getAuthHeaders() {
    return { 'Content-Type': 'application/json', 'Authorization': `Bearer ${accessToken}` };
  }

  // Theme toggle
  themeToggleBtn.addEventListener('click', () => {
    const current = document.documentElement.getAttribute('data-theme');
    const next = current === 'light' ? 'dark' : 'light';
    document.documentElement.setAttribute('data-theme', next);
    localStorage.setItem('nsf_theme', next);
    showToast(`Switched to ${next.toUpperCase()} mode`, 'info');
  });

  // Logout
  btnLogout.addEventListener('click', () => {
    sessionStorage.clear();
    window.location.href = 'index.html';
  });

  // -------------------------------------------------------
  // REQUESTER TOGGLE
  // -------------------------------------------------------
  function handleRequesterToggle() {
    if (radioForMe.checked) {
      userNameInput.classList.remove('hidden');
      userNameSelectWrapper.classList.add('hidden');
      userNameInput.value = currentUser;
      managerInput.value = USER_MANAGERS[currentUser] || 'ehab.makram';
      userNameInput.readOnly = true;
    } else {
      userNameInput.classList.add('hidden');
      userNameSelectWrapper.classList.remove('hidden');
      userNameInput.readOnly = false;
      const selectedUser = userNameSelect.value;
      if (USER_MANAGERS[selectedUser]) {
        managerInput.value = USER_MANAGERS[selectedUser];
      }
    }
  }

  radioForMe.addEventListener('change', handleRequesterToggle);
  radioOnBehalf.addEventListener('change', handleRequesterToggle);

  userNameSelect.addEventListener('change', () => {
    const selectedUser = userNameSelect.value;
    if (USER_MANAGERS[selectedUser]) {
      managerInput.value = USER_MANAGERS[selectedUser];
    }
  });

  // -------------------------------------------------------
  // CREATE BUTTON
  // -------------------------------------------------------
  btnCreateRequest.addEventListener('click', () => {
    const reqType = reqTypeSelect.value;
    const site = siteSelect.value;
    const finalUserName = radioForMe.checked ? userNameInput.value.trim() : userNameSelect.value;
    const finalManager = managerInput.value.trim();

    if (!reqType || !site) { showToast('Please select Req Type and Site first!', 'error'); return; }
    if (!finalUserName || !finalManager) { showToast('Please enter User Name and Manager!', 'error'); return; }

    radioForMe.disabled = true;
    radioOnBehalf.disabled = true;
    userNameInput.disabled = true;
    userNameSelect.disabled = true;
    managerInput.disabled = true;
    btnCreateRequest.disabled = true;

    isRequestCreated = true;
    requestDetailSection.classList.remove('disabled-section');
    requestDetailSection.classList.add('unlocked-section');
    reqDetailItemSelect.disabled = false;
    reqDetailSpecSelect.disabled = false;
    switchPrivate.disabled = false;
    reqOtherInput.disabled = false;
    reqRemarksArea.disabled = false;
    btnAddDetail.disabled = false;

    lockStatusBadge.className = 'lock-indicator unlocked';
    lockStatusBadge.innerHTML = `<svg width="14" height="14" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2.5"><polyline points="20 6 9 17 4 12"></polyline></svg><span>Request Details Unlocked</span>`;

    showToast('Requester created! Request Details unlocked.', 'success');
  });

  // -------------------------------------------------------
  // CASCADING DROPDOWN
  // -------------------------------------------------------
  reqDetailItemSelect.addEventListener('change', () => {
    const category = reqDetailItemSelect.value;
    reqDetailSpecSelect.innerHTML = '<option value="" disabled selected>Select Item Detail...</option>';
    const specs = SPEC_LOOKUPS[category] || [];
    specs.forEach(s => {
      const opt = document.createElement('option');
      opt.value = s; opt.textContent = s;
      reqDetailSpecSelect.appendChild(opt);
    });
  });

  // -------------------------------------------------------
  // ADD ITEM TO STAGING TABLE
  // -------------------------------------------------------
  switchPrivate.addEventListener('change', () => { privateLabel.textContent = switchPrivate.checked ? 'Yes' : 'No'; });
  reqRemarksArea.addEventListener('input', () => { charCount.textContent = `${reqRemarksArea.value.length} / 500 characters`; });

  btnAddDetail.addEventListener('click', () => {
    if (!isRequestCreated) { showToast('Click CREATE above first!', 'error'); return; }
    const reqItem = reqDetailItemSelect.value;
    const detailsSpec = reqDetailSpecSelect.value || 'Standard Detail';
    const isPrivate = switchPrivate.checked;
    const otherVal = reqOtherInput.value.trim() || '—';
    const remarksVal = reqRemarksArea.value.trim() || '';
    if (!reqItem) { showToast('Please select a Req category!', 'error'); return; }

    const tr = document.createElement('tr');
    tr.className = 'table-row';
    tr.innerHTML = `
      <td><strong>${escapeHtml(reqItem)}</strong></td>
      <td>${escapeHtml(detailsSpec)}</td>
      <td><span class="tag ${isPrivate ? 'tag-lock' : 'tag-gray'}">${isPrivate ? 'Yes' : 'No'}</span></td>
      <td>${escapeHtml(otherVal)}</td>
      <td class="remarks-cell">${escapeHtml(remarksVal)}</td>
      <td><span class="status-badge">Pending</span></td>
      <td class="text-right"><button type="button" class="btn-action-delete" title="Remove"><svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><polyline points="3 6 5 6 21 6"></polyline><path d="M19 6v14a2 2 0 0 1-2 2H7a2 2 0 0 1-2-2V6m3 0V4a2 2 0 0 1 2-2h4a2 2 0 0 1 2 2v2"></path></svg></button></td>
    `;
    tr.dataset.req = reqItem; tr.dataset.details = detailsSpec;
    tr.dataset.private = isPrivate; tr.dataset.other = otherVal;
    tr.dataset.remarks = remarksVal; tr.dataset.status = 'Pending';
    tableBody.appendChild(tr);
    updateStagingTableState();

    reqDetailItemSelect.value = '';
    reqDetailSpecSelect.innerHTML = '<option value="" disabled selected>Select Item Detail...</option>';
    switchPrivate.checked = false; privateLabel.textContent = 'No';
    reqOtherInput.value = ''; reqRemarksArea.value = '';
    charCount.textContent = '0 / 500 characters';
    showToast(`Added "${reqItem}" to details grid`, 'success');
  });

  tableBody.addEventListener('click', (e) => {
    const btn = e.target.closest('.btn-action-delete');
    if (btn) { btn.closest('tr').remove(); updateStagingTableState(); showToast('Item removed', 'info'); }
  });

  function updateStagingTableState() {
    const rowCount = tableBody.querySelectorAll('tr').length;
    itemsCountBadge.textContent = `${rowCount} Item${rowCount === 1 ? '' : 's'} Added`;
    if (rowCount === 0) { emptyState.classList.remove('hidden'); requestsTable.classList.add('hidden'); }
    else { emptyState.classList.add('hidden'); requestsTable.classList.remove('hidden'); }
  }

  // -------------------------------------------------------
  // SAVE TICKET
  // -------------------------------------------------------
  btnSave.addEventListener('click', async () => {
    if (!isRequestCreated) { showToast('Please click CREATE first!', 'error'); return; }
    const rows = Array.from(tableBody.querySelectorAll('tr'));
    if (rows.length === 0) { showToast('Add at least 1 detail line!', 'error'); return; }

    const reqNo = reqNoInput.value;
    const payload = {
      Req_No: reqNo,
      Req_Type: reqTypeSelect.value,
      Site: siteSelect.value,
      Requester_Option: radioForMe.checked ? 'For Me' : 'On behalf of:',
      User_Name: radioForMe.checked ? userNameInput.value.trim() : userNameSelect.value,
      Manager: managerInput.value.trim(),
      Created_By: currentUser,
      DetailsList: rows.map(r => ({
        Req_No: reqNo, Req: r.dataset.req, Details: r.dataset.details,
        Private: r.dataset.private === 'true', Other: r.dataset.other,
        Remarks: r.dataset.remarks, Status: r.dataset.status || 'Pending'
      }))
    };

    try {
      showToast(`Submitting ticket ${reqNo}...`, 'info');
      const res = await fetch(`${activeServerBase}/api/Ticket/SaveTicket/`, {
        method: 'POST', headers: getAuthHeaders(), body: JSON.stringify(payload)
      });
      if (res.ok) {
        showToast(`Ticket ${reqNo} saved to SQL database!`, 'success');
        resetFormToInitial(); fetchAllTickets();
      } else { throw new Error(await res.text()); }
    } catch (err) {
      console.error('SaveTicket error:', err);
      showToast(`Save error: ${err.message}`, 'error');
    }
  });

  // -------------------------------------------------------
  // RESET FORM
  // -------------------------------------------------------
  function resetFormToInitial() {
    tableBody.innerHTML = ''; updateStagingTableState(); fetchNextReqNo();
    isRequestCreated = false;
    requestDetailSection.classList.add('disabled-section');
    requestDetailSection.classList.remove('unlocked-section');
    reqDetailItemSelect.disabled = true; reqDetailSpecSelect.disabled = true;
    switchPrivate.disabled = true; reqOtherInput.disabled = true;
    reqRemarksArea.disabled = true; btnAddDetail.disabled = true;
    lockStatusBadge.className = 'lock-indicator';
    lockStatusBadge.innerHTML = `<svg width="14" height="14" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><rect x="3" y="11" width="18" height="11" rx="2" ry="2"></rect><path d="M7 11V7a5 5 0 0 1 10 0v4"></path></svg><span>Click CREATE above to unlock</span>`;
    radioForMe.disabled = false; radioOnBehalf.disabled = false;
    userNameInput.disabled = false; userNameSelect.disabled = false;
    managerInput.disabled = false; btnCreateRequest.disabled = false;
    handleRequesterToggle();
  }

  btnNew.addEventListener('click', () => {
    resetFormToInitial(); reqTypeSelect.value = ''; siteSelect.value = '';
    showToast(`Initialized fresh ticket`, 'info');
  });

  // -------------------------------------------------------
  // API CALLS
  // -------------------------------------------------------
  async function fetchUsersAPI() {
    try {
      const res = await fetch(`${activeServerBase}/api/Ticket/GetUsers/`, { headers: getAuthHeaders() });
      if (res.ok) {
        const users = await res.json();
        userNameSelect.innerHTML = '';
        users.forEach(u => {
          USER_MANAGERS[u.Name] = u.ManagerName || 'ehab.makram';
          const opt = document.createElement('option');
          opt.value = u.Name; opt.textContent = u.Name;
          userNameSelect.appendChild(opt);
        });
      }
    } catch (err) { console.warn('GetUsers error:', err); }
  }

  async function fetchNextReqNo() {
    try {
      const res = await fetch(`${activeServerBase}/api/Ticket/GetNextReqNo/`, { headers: getAuthHeaders() });
      if (res.ok) { reqNoInput.value = await res.json(); }
    } catch (err) { reqNoInput.value = 'REQ-0008'; }
  }

  async function fetchAllTickets() {
    try {
      const res = await fetch(`${activeServerBase}/api/Ticket/GetAllTickets/`, { headers: getAuthHeaders() });
      if (res.ok) {
        const tickets = await res.json();
        renderAllTicketsGrid(tickets);
        savedTicketsCount.textContent = tickets.length;
      }
    } catch (err) { savedTicketsCount.textContent = '0'; renderAllTicketsGrid([]); }
  }

  function renderAllTicketsGrid(tickets) {
    allTicketsTableBody.innerHTML = '';
    if (!tickets || tickets.length === 0) { allTicketsEmptyState.classList.remove('hidden'); return; }
    allTicketsEmptyState.classList.add('hidden');
    tickets.forEach(t => {
      const tr = document.createElement('tr');
      tr.className = 'table-row';
      const date = t.Created_Date ? new Date(t.Created_Date).toLocaleDateString() : 'Today';
      tr.innerHTML = `
        <td><strong style="color:var(--primary-color);">${escapeHtml(t.Req_No)}</strong></td>
        <td><span class="tag tag-gray">${escapeHtml(t.Req_Type || 'N/A')}</span></td>
        <td>${escapeHtml(t.Site || 'N/A')}</td>
        <td>${escapeHtml(t.Requester_Option || 'For Me')}</td>
        <td><strong>${escapeHtml(t.User_Name || 'System')}</strong></td>
        <td>${escapeHtml(t.Manager || 'None')}</td>
        <td>${date}</td>
        <td><span class="badge badge-subtle">${t.TotalItems || 0} items</span></td>
        <td class="text-right"><button type="button" class="btn-action-delete btn-delete-ticket" data-reqno="${escapeHtml(t.Req_No)}" title="Delete"><svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2"><polyline points="3 6 5 6 21 6"></polyline><path d="M19 6v14a2 2 0 0 1-2 2H7a2 2 0 0 1-2-2V6m3 0V4a2 2 0 0 1 2-2h4a2 2 0 0 1 2 2v2"></path></svg></button></td>
      `;
      allTicketsTableBody.appendChild(tr);
    });
  }

  // Tab Navigation
  tabNewRequestBtn.addEventListener('click', () => {
    tabNewRequestBtn.classList.add('active'); tabAllTicketsBtn.classList.remove('active');
    viewNewRequest.classList.remove('hidden'); viewAllTickets.classList.add('hidden');
  });
  tabAllTicketsBtn.addEventListener('click', () => {
    tabAllTicketsBtn.classList.add('active'); tabNewRequestBtn.classList.remove('active');
    viewAllTickets.classList.remove('hidden'); viewNewRequest.classList.add('hidden');
    fetchAllTickets();
  });

  // Hash-based tab switching (from dashboard "Saved Tickets" card)
  if (window.location.hash === '#tickets') {
    tabAllTicketsBtn.click();
  }

  copyReqNoBtn.addEventListener('click', () => {
    navigator.clipboard.writeText(reqNoInput.value).then(() => showToast(`Copied ${reqNoInput.value}`, 'info'));
  });

  btnRefreshTickets.addEventListener('click', () => { fetchAllTickets(); showToast('Refreshed tickets', 'info'); });

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

  function escapeHtml(str) {
    if (!str) return '';
    return String(str).replace(/[&<>"']/g, m => ({ '&': '&amp;', '<': '&lt;', '>': '&gt;', '"': '&quot;', "'": '&#039;' }[m]));
  }

  // Initialize
  updateStagingTableState();
  fetchNextReqNo();
  fetchAllTickets();
  fetchUsersAPI();
});
