# APPLICATION DESCRIPTION
Inventory tracking, invoice processing, variance reporting, recipe management application
Chefs that are used to paper and pencil don't want to switch to a data-heavy application
These are the target users, so the application should be lightweight and easy to use
This means minimum load time, miniumum barrier-to-entry, and minimum data entry




# BEFORE ANYTHING ELSE
 The list has grown very long and intimidating, so let's pick something to start with
 Review our models, fix our schema, update the ERD, etc.
 In other words, we know better now what our database should look like, so let's fix it
 Then we can move on to adding functionality and making things work nicer
 On top of that, we have to start version control, right now, for tons of reasons
- [x] Get on GitHub, establish version control, and start committing code
- [x] Resolve issue with Product, Supplier, and ProductSupplier models
- [x] We have another issue with these. ProductSupplier is now a useless entity
- [x] Remove ProductSupplier, navigation properties, configuration, seed data
- [x] Really need to make sure we clean this up - it's been a while since creating the models/schema
- [x] Check Fluent API config for Product, Supplier, and ProductSupplier (review Fluent API as well)
- [x] Check controllers, views, etc.
- [x] Product should now have a zero or many to zero or one relationship with supplier
- [x] Create a new migration and update the database - tested clean
- [x] Update product and invoiceproduct models to reflect updated schema
- [x] Update configuration files and seed data to reflect updated schema
- [ ] Update ProductViewModel, controller, and view to allow Product page to still display unit and price
- [ ] Update AddProduct view to allow for selecting a supplier (required)
- [ ] Implement new MiscProduct entity
- [ ] Implement UI changes for MiscProduct - requires a separate view, controller, etc.

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
- [x] AddProduct view category selectlist should be populated from category model
- [x] AddProduct Category selectlist is now reloaded upon validation failure
- [ ] AddProduct view unit type selectlist should be populated somehow, not hard-coded, new model maybe
- [ ] AddInvoice view should have a select list for suppliers
- [ ] Implement views for updating products, suppliers, invoices, recipes
- [ ] Implement buttons for deleting products, suppliers, invoices, recipes
- [x] Product and inventory views should display category name, not Id
- [x] Establish cascade and required behavior for supplier, invoice, invoiceproduct, and product
- [x] Changed all configuration files, Fluent for required relationships, composite keys, and cascade delete behavior
- [x] Modified gitignore file for common security concerns
- [x] New migration, updated database, sanity check successful
- [x] Test the app again to make sure we didn't break anything - add product failed, other add pages succeed
- [ ] This might be a good time to learn about unit tests, it's becoming cumbersome to test the app
- [ ] This would also be a good time to add delete buttons, so we can test cascade behaviors

# LATER ON
- [x] Reconcile navbar with views 
- [x] Add seed data to dbcontext
- [x] Configuration files for each model
- [x] Remove cascading delete for certain models
- [ ] Account for historical data
- [x] Addproduct, recipe, invoice, supplier, category should be pop-up pages instead of embedded in view
- [ ] Separate HomeController into separate controllers for each view
- [ ] Remove IDs from the displayed tables, but leave for now for ease of development
- [ ] Add local and server-side validation to all models
- [ ] Populate invoice list view with invoiceproduct line items, supplier name
- [ ] Populate recipe list view with recipeproduct line items
- [ ] Forms should return to the same form with the same information if validation fails
- [ ] Forms should return to the list view for that model if validation succeeds
- [ ] Fix datetime format in invoice list view, fix datetime input box in add invoice view
- [ ] Invoice view needs a lot of functionality - display items, add items, delete items, etc.
- [ ] Add 'search by Id' ala Chapter something from murach's
- [ ] Unit price and total value should be in either inventory or product views, not both

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

# MAJOR BLOCKER DATABASE REMODEL 8/18/25
Problem: What if a product has multiple suppliers, each with a different price?
Solution: The solution we've settled on is to create a new business rule: each product used in
a recipe will have one and only one 'default' supplier. If a manager needs to purchase an item or
product from a grocery store or other 'alternative' supplier, they can do so, but they add this 
as a separate 'misc product' which is not tracked the same as our other products. This means we 
need to give these misc products their own entity - they don't need to be related to an existing 
supplier, but we still need to track their name/description, unit type, unit price, and quantity.
Other fields could include manager name, reason for purchase, location of purchase, etc.
These misc products will not be associated with any recipes. At the end of the week, when the 
manager analyzes inventory, they check a misc product report and compare it to our product variances.
Thus, if they see 'missing ten pounds of roma tomatoes' they can match this shortfall to the relevant
miscellaneous product. Additionally, a report could be made that tracks how much money was 'lost' or
'gained' by using these miscellaneous products in place of our standard suppliers. To go a step
further, we could add a UI that let's a manager actually check in these misc products in place of 
regular products so that a report can be generated that shows we are not 'missing product' as a result
of waste or spoilage but rather due to a discrepency between official products and misc products.
This way, managers know we may have spent more than we wanted to, but we aren't actually missing anything.

# MAJOR BLOCKER BUXFIX 6/5/2025
This is a review of the steps we had to take to fix a major bug that was preventing us from adding products.
After making some major changes to the models and views, we were unable to add products. When we filled in the
AddProduct form and clicked submit, the page reloaded but no entries were changed, the product wasn't added, and
no error messages showed. We figured out that the the model state was considered invalid, but we didn't know why.
Eventually, we added some validation messages and discovered that CategoryId was not binding - the error messages 
were "The Category field is required" and "The Categories field is required." To correct this, we added a viewmodel
for AddProduct and we modified the category dropdown to a SelectList of categories, made sure to reload the 
selectlist if the validation failed, and updated the view to use the new SelectList. Important to note is we used two 
using statements: "using Microsoft.AspNetCore.Mvc.ModelBinding; using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;"
- [x] Added strongly typed ViewModel using [BindNever] and [ValidateNever] for the selectlist.
- [x] Bound razor inputs within the AddProduct view to the ViewModel, changed inputs to 'Product.ProductName', etc.
- [x] Added a range validation to the Product.CategoryId property so that zero is not a valid value.
- [x] Told ASP.NET not to validate the Product model's Category navigation property since the full object isn't used.
We will likely run into this problem as we add functionality to the other models, so it is important to review this
and ensure that we understand the problems, the solution, and also to determine if this solution is the best one.
