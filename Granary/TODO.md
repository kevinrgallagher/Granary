# APPLICATION DESCRIPTION
Inventory tracking, invoice processing, variance reporting, recipe management application


# REMODELING DATABASE
- [ ] There's still something bothering me about my schema re: product, supplier, supplierproduct
- [ ] What if a product has multiple suppliers, each with a different price?
- [ ] Should products be unique by name, unit type, supplier, or some combination?
- [ ] Look into how we handled inventory model in the Warehouse database, might help
- [ ] Inventory should be the primary model, product should almost be a property of inventory


# BEFORE ANYTHING ELSE
 The list has grown very long and intimidating, so let's pick something to start with
 Review our models, fix our schema, update the ERD, etc.
 In other words, we know better now what our database should look like, so let's fix it
 Then we can move on to adding functionality and making things work nicer
 On top of that, we have to start version control, right now, for tons of reasons
- [x] Get on GitHub, establish version control, and start committing code
- [ ] Resolve issue with Product, Supplier, and ProductSupplier models
- [ ] Add attributes to other models as necessary - we have a good scaffold, build it out
- [ ] Make sure to update configuration file seed data, views, controllers, etc.
- [ ] Create a new migration and update the database



# TODO
- [x] Scaffold views, controllers
- [x] Imported entity framework packages
- [x] Added using statements and performed basic setup in program.cs
- [x] Start modifying default layout, added navbar, removed footer, placeholder content
- [x] Modified launchSettings.json to only use development environment and https
- [x] Index page now loads with basic table of seed products
- [x] Added some basic models, need to develop ERD and database schema before continuing
- [x] Created basic ERD on LucidChart, made models, added many-to-many relationship properties
- [x] Added dbcontext file
- [x] Add navigation properties for join tables and related tables
- [x] Added join table for ProductSupplier for consistency
- [x] Added category model and updated ERD, views, and related models
- [x] Finalize ERD Version 1.0
- [x] Added configuration files with seed data for all eight models
- [x] Double-checked navigation properties, added comments to models to clarify relationships
- [x] Migrate initial database - warnings - fixed decimal precision issue - success
- [x] Suppressed a number of code style messages in migration file
- [x] Update database - sanity check - success
- [x] Built out the Product view, wired nav link, need to add action method to controller for submission
- [x] Product, invoice, recipe, supplier views now display a list of items
- [x] Implemented views and controllers for adding products, invoices, recipes, and suppliers
- [x] Index view should become a welcome page, build out Inventory view to display product counts/values
- [x] Inventory view changes, added viewmodel for formatting data and removing trailing zeroes
- [x] Product view changes, added viewmodel for formatting data and removing trailing zeroes
- [x] Supplier model should contain more properties such as contact info, address, etc.
- [x] Invoice model should contain more properties such as issue number, due date, etc.
- [x] Fix datetime format on invoice list and addinvoice form 
- [x] Name properties for models should be made consistent, either 'Name' or 'SupplierName' for instance
- [x] Added required tags to all attributes for all models 
- [x] Add more validation
- [ ] AddProduct view category selectlist should be populated from category model
- [ ] AddProduct view unit type selectlist should be populated somehow, not hard-coded, new model maybe
- [ ] AddInvoice view should have a select list for suppliers
- [ ] Implement views for updating products, suppliers, invoices, recipes
- [ ] Implement buttons for deleting products, suppliers, invoices, recipes
- [x] Product and inventory views should display category name, not Id
- [x] Establish cascade and required behavior for supplier, invoice, invoiceproduct, and product
- [x] Changed all configuration files, established requirements, composite keys, and cascade delete behavior
- [x] Modified gitignore file for common security concerns
- [	] New migration, updated database, sanity check successful
- [ ] Test the app again to make sure we didn't break anything
- [ ] This might be a good time to learn about unit tests, it's becoming cumbersome to test the app
- [ ] This would also be a good time to add delete buttons, so we can test cascade behaviors


# REVIEW MATERIAL
- [x] Navigation properties, under-the-hood explanation
- [ ] DbContext class in general, under-the-hood explanation, configuration classes
- [ ] Domain models
- [ ] Grid views
- [ ] Repositories
- [ ] Query builders
- [ ] Select lists populated from database
- [x] Get on github and start version controlling and committing
- [ ] Look into Copilot - I think there's a full agent available - Github Models Hub?


# LATER ON
- [x] Reconcile navbar with views 
- [x] Add seed data to dbcontext
- [x] Configuration files for each model
- [ ] Remove cascading delete for certain models
- [ ] Consider storing historical data
- [x] Addproduct, recipe, invoice, supplier, category should be pop-up pages instead of embedded in view
- [ ] Separate HomeController into separate controllers for each view
- [ ] Remove IDs from the displayed tables, but leave for now for ease of development
- [ ] Add local and server-side validation to all models
- [ ] Dropdown for Product page so user can select a supplier for that product and see the price
- [ ] Populate invoice list view with invoiceproduct line items, supplier name
- [ ] Populate recipe list view with recipeproduct line items
- [ ] Populate supplier list with supplierproduct line items
- [ ] Forms should return to the same form with the same information if validation fails
- [ ] Forms should return to the list view for that model if validation succeeds
- [ ] Fix datetime format in invoice list view, fix datetime input box in add invoice view
- [ ] Invoice view needs a lot of functionality - display items, add items, delete items, etc.
- [ ] 

