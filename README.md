# AgePay

# hello worlds!

update your user's permissions to:
```shell
["frmEmployeeProfile",
            "frmEditDepo",
            "frmEditHoliday",
            "frmImportData",
            "frmExportAttendance",
            "frmEditTimeRegister",
            "frmManualTimeRegister",
            "frmAdvanceRegister",
            "frmLoanRegister",
            "frmSalaryRegister",
            "frmLogin",
            "frmEditUserPrivlidges"]
```
---
---

## 🛠️ `7/28/2025` — Big Fix Day!

### 🔧 General Fixes
- [x] Don't hide `Form1` when a subform loads.
  - [x] Prevent accidental hiding
  - [x] Maintain parent visibility
  - [x] Adjust z-order for subforms
- [x] Hide links to forms that the user isn't authorized to access.
  - [x] Check user roles at runtime
  - [x] Hide buttons dynamically
  - [x] Prevent access even via URL/path hacks
- [x] Add calendar popups to all date input fields across all forms.
  - [x] Attach calendar to DOB fields
  - [x] Integrate with joining date inputs
  - [x] Use consistent date format across app
- [x] Rebuild and update the `ManualAttendanceForms`.
  - [x] Delete legacy code
  - [x] Redesign UI layout
  - [x] Integrate database hooks
- [x] Ensure proper focus behavior on all forms.
  - [x] Set default focus on load
  - [x] Trap Tab key properly
  - [x] Fix focus loss on dialog close

---

### 👤 `EmployeeProfile` Enhancements
- [x] Calendar integration complete.
  - [x] Connect calendar to join/leave dates
  - [x] Format values consistently
- [x] Fixed image load/save/display errors.
  - [x] Validate image types
  - [x] Add error handling on load
  - [x] Ensure compatibility across OS versions
- [x] Improved open/save logic.
  - [x] Add confirmation prompts
  - [x] Prevent duplicate entries
- [x] Miscellaneous bug fixes.
  - [x] Label misalignments
  - [x] Typos in field names
- [x] Focus behavior fixed.
  - [x] Auto-focus on first editable field
  - [x] Refocus after save or cancel

---

### ⏱️ `EditTime` Module
- [x] Added calendar support.
  - [x] Inline calendar for quick edits
  - [x] Popup calendar for full date range
- [x] Implemented edit tracking and validation.
  - [x] Prevent future time entries
  - [x] Validate overtime limits
- [x] Fixed known errors.
  - [x] Error on empty time field
  - [x] Crash on edge cases
- [x] Fixed focus handling.
  - [x] Focus jumps to next field
  - [x] Fixed Tab/Enter behavior

---

### 🏖️ `EditHoliday` Form
- [x] Calendar functionality added.
  - [x] Show holiday picker
  - [x] Disable past dates
- [x] Focus flow improved.
  - [x] Set tab order
  - [x] Focus on holiday name by default
- [x] Fixed database issues.
  - [x] Corrected save logic
  - [x] Fixed duplicate holiday bug

---

### 🔐 `LoginForm` Updates
- [x] Improved focus control.
  - [x] Focus on username field
  - [x] Move to password on Enter
- [x] Added superadmin-specific logic.
  - [x] Unlock hidden menus
  - [x] Log superadmin sessions
- [x] Enhanced Enter key behavior.
  - [x] Submit form on Enter
  - [x] Block empty field submission

---

### 🧭 `MainPanel` Improvements
- [x] Hide inaccessible buttons based on permissions.
  - [x] Check user roles on login
  - [x] Hide UI elements accordingly
- [x] Prevent hiding of the main form.
  - [x] Override close/hide events
  - [x] Add confirmation before exit
- [x] Updated permission logic.
  - [x] Add granular control per feature
  - [x] Audit permission checks
- [x] Added permissions for Loan, Advance, and Salary sections.
  - [x] Create new permission entries
  - [x] Connect to access control system
  - [x] Test with sample roles

---

### 📆 `ManualAttendanceForms`
- [x] Completely rebuilt the form from scratch for better performance and maintainability.
  - [x] New UI layout with cleaner design
  - [x] Integrated real-time validation
  - [x] Connected to updated attendance DB
  - [x] Added comments/notes section
  - [x] Focus flow and keyboard shortcuts


---
---


## LOGIN
<img width="919" height="793" alt="image" src="https://github.com/user-attachments/assets/860acbf5-6f5f-45b0-9e4b-305e6ff42d34" />

## MAINPANEL
<img width="1711" height="878" alt="image" src="https://github.com/user-attachments/assets/d200624a-976e-4743-b6ec-fb417f9e2e1d" />

### NOT ALLOWED THING!
<img width="544" height="306" alt="image" src="https://github.com/user-attachments/assets/9b509c97-ff26-4712-b55d-946a9d287c24" />

### MORE

<img width="432" height="298" alt="image" src="https://github.com/user-attachments/assets/36db4de1-3bca-441b-8b5b-0e61c7f442dd" />
<img width="823" height="644" alt="image" src="https://github.com/user-attachments/assets/20578b2f-d238-488e-acdb-8e709dcf19c7" />
<img width="604" height="308" alt="image" src="https://github.com/user-attachments/assets/ae90770e-630b-44ac-856c-2fa4d202b017" />

## MANUAL ATTENDNACE
<img width="635" height="474" alt="image" src="https://github.com/user-attachments/assets/148a2c27-083a-46f2-b9ed-212702cd88e8" />

<img width="658" height="532" alt="image" src="https://github.com/user-attachments/assets/77fb0895-eda9-42c3-b390-9461a91571f8" />
<img width="527" height="256" alt="image" src="https://github.com/user-attachments/assets/90cb99ac-f17f-4ec8-8465-26d88685638d" />

### IF USER HAS ALREADY ADDTENSNCEECD!

<img width="673" height="518" alt="image" src="https://github.com/user-attachments/assets/ea3a068a-411a-495b-9736-75b580a33ff7" />


## DAILY REGISTER

<img width="1027" height="828" alt="image" src="https://github.com/user-attachments/assets/3178abbe-38d9-46dc-a83e-5f1382508661" />
<img width="525" height="609" alt="image" src="https://github.com/user-attachments/assets/91be07ad-25b3-4183-8a2a-e10cfe7804a0" />


## HOLIDAY
<img width="1192" height="580" alt="image" src="https://github.com/user-attachments/assets/ab113935-f6e1-4c46-8448-76c84eb340bc" />
<img width="488" height="278" alt="image" src="https://github.com/user-attachments/assets/62af721e-663e-49bd-9fb4-f06d093a0a9a" />
<img width="531" height="251" alt="image" src="https://github.com/user-attachments/assets/1276c8da-5cfe-4406-a0c4-590a644f0f4a" />
<img width="824" height="424" alt="image" src="https://github.com/user-attachments/assets/ecf5523e-5d77-4046-a3d2-c175612ed1f8" />
<img width="689" height="398" alt="image" src="https://github.com/user-attachments/assets/a2f5461f-9032-41af-8a25-f2ffdd43bf30" />
### DONT PRESSTHIS: 
<img width="144" height="61" alt="image" src="https://github.com/user-attachments/assets/1a7e2ce6-b39e-43fb-9bc4-f9fa20dc2155" />
