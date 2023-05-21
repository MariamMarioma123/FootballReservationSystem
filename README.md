# FootballReservationSystem
The project aims to develop a system that manages matches played in any sport and keeps track of fan attendance. The system has several requirements:

-Sports Association Manager: The manager can create, edit, and delete matches for different clubs.

-Matches: Matches involve two clubs, with one acting as the host. Each match has an ID, starting and ending times, and an allowed number of attendees. Matches are played in specific stadiums.

-Clubs: Each club has an ID, name, and location. A representative from the club is responsible for requesting permission to host matches. The representative has a name and ID.

-Stadiums: Stadiums have an ID, name, capacity, location, and status. The status can be available or not available. Each stadium has a manager who approves or disapproves club requests to host matches.

-Tickets: Once a stadium manager approves a match, tickets become available for fans to purchase. Each ticket has an ID, the stadium where the match is hosted, and a status of sold or available. The system keeps a record of which users have bought which tickets.

-Fans: Fans have a name, national ID number, birth date, address, and phone number. They can buy tickets to attend matches. In some cases, a fan can be temporarily blocked from using the system.

-System Admin: The system admin has the authority to add or delete clubs, stadiums, and fans. They can also temporarily block fans from using the system.

-User Authentication: All users of the system, including the association manager, club representatives, stadium managers, and fans, have a unique username and password to access the system.

This project involves implementing a database system for managing matches in a sport and tracking fan attendance. The project has several requirements, including the creation, deletion, and editing of matches for different clubs, management of clubs, stadiums, and fans, user authentication, and various data retrieval operations. The following milestones and their descriptions summarize the requirements:

1-Basic Structure of the Database:

-createAllTables: A stored procedure that creates all the tables in the database.

-dropAllTables: A stored procedure that drops all tables in the database.

-dropAllProceduresFunctionsViews: A stored procedure that drops all implemented stored procedures, functions, and views.

-clearAllTables: A stored procedure that clears all records from all tables in the database.


2-Basic Data Retrieval:

-allAssocManagers: A view that fetches the username, password, and name for all association managers.

-allClubRepresentatives: A view that fetches the username, password, name, and represented club name for all club representatives.

-allStadiumManagers: A view that fetches the username, password, name, and managed stadium name for all stadium managers.

-allFans: A view that fetches the username, password, name, national ID number, birth date, and status (blocked or unblocked) for all fans.

-allMatches: A view that fetches the name of the host club, the name of the guest club, and the start time for all matches.

-allTickets: A view that fetches the name of the host club, the name of the guest club, the name of the stadium hosting the match, and the start time of the match for all tickets.

-allClubs: A view that fetches the name and location for all clubs.

-allStadiums: A view that fetches the name, location, capacity, and status (available or unavailable) for all stadiums.

-allRequests: A view that fetches the username of the club representative sending the request, username of the stadium manager receiving the request, and the status of the request for all requests.


3-All Other Requirements:

-addAssociationManager: A stored procedure that adds a new association manager with the given information.

-addNewMatch: A stored procedure that adds a new match with the given information.

-clubsWithNoMatches: A view that fetches the names of all clubs that have not been assigned to any match.

-deleteMatch: A stored procedure that deletes the match with the given information.

-deleteMatchesOnStadium: A stored procedure that deletes all matches scheduled to be played in a specific stadium.

-addClub: A stored procedure that adds a new club with the given information.

-addTicket: A stored procedure that adds a new ticket for a match with the given information.

-deleteClub: A stored procedure that deletes the club with the given name.

-addStadium: A stored procedure that adds a new stadium with the given information.

-deleteStadium: A stored procedure that deletes the stadium with the given name.

-blockFan: A stored procedure that blocks a fan with the given national ID number.

-unblockFan: A stored procedure that unblocks a fan with the given national ID number.

-addRepresentative: A stored procedure that adds a new club representative with the given information.

-viewAvailableStadiumsOn: A function that returns a table of available stadiums for reservation on a given date.

-addHostRequest: A stored procedure that adds a new request from a club representative to a stadium representative regarding hosting a match.

-allUnassignedMatches: A function


The web application itself had these requirements as a must:

1-System Admin:

-Add a new club with its name and location.

-Delete a club using its name.

-Add a new stadium with its name, location, and capacity.

-Delete a stadium using its name.

-Block a fan using their national ID number.


2-Sports Association Manager:

-Register with a name, username, and password.

-Add a new match with the host club name, guest club name, start time, and end time.

-Delete a match with the host club name, guest club name, start time, and end time.

-View all upcoming matches (host club name, guest club name, start time, and end time).

-View already played matches (host club name, guest club name, start time, and end time).

-View pairs of club names that have never scheduled to play with each other.


3-Club Representative:

-Register with a name, username, password, and the name of an existing club.

-View all related information of the club they are representing.

-View all upcoming matches for the club (host club name, guest club name, start time, end time, and the hosting stadium's name if available).

-View all available stadiums starting from a certain date (stadium name, location, and capacity).

-Send a request to a stadium manager to host an upcoming match for their club.


4-Stadium Manager:

-Register with a name, username, password, and the name of an existing stadium.

-View all related information of the stadium they are managing.

-View all received requests (sending club representative's name, host club name, guest club name, start time, end time, and request status).

-Accept or reject a pending request.


5-Fan:

-Register with a name, username, password, national ID number, phone number, birth date, and address.

-View all matches with available tickets starting from a given time (host club name, guest club name, hosting stadium name, and location).

-Purchase a ticket for a match.

-Remember to validate the data passed from the interface to the database to ensure its validity.
