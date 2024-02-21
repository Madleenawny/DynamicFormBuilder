This project involves the development of a WinForms application with three main forms:

Main Form:

Two buttons: "Create Form" and "Choose Form."
"Create Form" opens a form where users can design custom forms by adding buttons, textboxes, integer inputs, double inputs, checkboxes, and labels. Users can customize control properties such as control name, size, and location.
Upon clicking "Save," the form's name and controls, along with their coordinates, are stored in a master table.
Create Form:

Allows users to design custom forms by adding various controls.
User-configurable properties include control name, size (X, Y), and location.
Clicking "Save" adds the form name and control details to a master table in the database.
Choose Form:

Displays a dropdown menu populated with existing form names.
Upon selecting a form, the associated controls (excluding labels) are shown.
Users can input data into these controls, and clicking "Save" updates the corresponding table in the database.
If the selected form does not exist in the database, a new table is created with columns corresponding to the controls, and user data is inserted.
