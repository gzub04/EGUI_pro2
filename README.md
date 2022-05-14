# EGUI
 Second of three projects for **GUI** classes at Warsaw University of Technology.
 
 ### Short description
 Basic blog application made in ASP.MVC.  
 Data management was done in SQL Database.
 
 ## Full task: Blog application in ASP.MVC
- Please write simple Blog Application using ASP.MVC (under linux) - using .net core 6.0
- Please use Bootstrap for GUI design

## Application should enable:
- user registration
- login for registered users
- after login:
  - display list of the blogs
  - creation of the new blog
  - delete of the blog (only blog created by me)
  - display content of the selected blog
    - title
    - id of the owner
    - date/time of publication
    - content
  - after selecting a blog user may:
    - add new entry in the blog
    - delete own entry from the blog
    - modify own entry in the blog
- Application should contains following views (windows/dialogs)
  - login view
  - registration view
  - list of blogs view
  - single blog view
  - entry add/edit/create view

The most important part of the task is to make sure the user interface behaves correctly, e.g.:
- You cannot create a user without an id or with id similar to an existing one
- You cannot confirm creating a blog entry if not all mandatory data is filled in
- If list of entries is empty, "remove" button is disabled
- Data is edited using widgets appropriate for that data type
- Regular desktop application look and feel is maintained (e.g. toolbars, menus, item selection)
- Resizing windows does not cause content to disappear or unused empty space to appear in the window
- Code quality is considered during evaluation
