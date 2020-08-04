<h1>PickNTour</h1>

*An overhaul of my old class project Veto Tours*

Conceptual On-Demand Tour Booking system which features:
* Creation of Tours
* Booking of Tours
* Personal Messaging System
* Administrative Backend

Development Platform & Languages:
* ASP.NET Core 3.0 MVC
* Entity Framework Focused
* C#
* CSHTML
* Javascript
* AJAX

*Feel free to look at PickNTour App Images Folder to see images of all the current features!*

<h2>Current Features</h2>

**<h3>User Module:</h3>**
  * Homepage:
    * User Summary:
      * Unread Messages Count
      * Upcoming Bookings Count
      * Completed Tours Count
      
  * Tours:
    * View Available Tours:
      * Book Tour
      * View Tour Details
      
    * View Upcoming Bookings:
      * Message Tour Guide
      * Cancel Booking
      
    * View Booking History

    
  * Personal Messaging:
    * View Inbox:
      * View Messages
      * Reply to Sender
      * Delete Messages
      
    * Compose Message:
      * AutoComplete Username Query
      
      
**<h3>Tour Guide Module:</h3>**
  * Homepage:
    * User Summary:
      * Unread Messages Count
      * Upcoming Tours Count
      * Completed Tours Count
      
  * Tours:
    * Create a Tour

    * Manage Tours:
      * Edit Existing Tour
      * View Tour Participants:
        * Message all Participants of a Tour
      * Delete Tour:
        * Auto Message all affected Tour Participants

  * Personal Messaging (Same features as regular user)
  
  
**<h3>Admin Module:</h3>**
  * User Management:
    * View all Registered users
    
    * View all Locked Out users
    
    * Lockout User:
      * Auto remove user bookings
      * Auto message affected tour guide if auto-removed booking from lockedout user is made to an upcoming tour.
      
    * Lockout Tour Guide:
      * Auto remove created tours
      * Auto remove user bookings made to tour
      * Auto message affected users if they made a booking to an upcoming tour by the locked out tourguide.
      
    * Release Lockout
      
      
**<h2>Planned Future Features:</h2>**
* Google Maps integration for Tour Locations in Tour Details
* Allow Tour Guides to set Currency Type for Tour Prices based on Country
* Allow Users to specify how many slots they wish to book
* Minimum Slot booking to fufill 'x' days before Tour Start Date or Auto-Cancel
* Allow Tour Guides to set GMT offset for their Tour.
* Auto Paging of Available Tours
* Allow Tour Guides to upload custom pictures that will be displayed to users in Available Tours
* More Administrative Actions for Admin Users and a new Homepage rework
      
    
   
