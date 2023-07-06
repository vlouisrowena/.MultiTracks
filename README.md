## MultiTracks Assessment Solution!

This solution consists of:
  - artistDetails.aspx page that displays an artist's information of a given id.
      - Change artistID the sql parameter to get a different artist's information in artistDetails.aspx.cs
  - MultiTracksAPI has 3 end points:
      -  /artist/search: Search artist information by name. 
      -  /artist/add: Add an artist by entering title, biography, imageURL, heroURL
      -  /song/list: pageNumber- the page number of songs and pageSize- number of songs on each page. Maximum number of songs on one page is 30.
        
     Swagger UI is used to visualize the endpoints and the exchange of data. 


To get started:

- Clone the repo locally	
- Open the solution in Visual Studio	
- Run "Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r" from the Package Manager Console	for each project (MTDataAccess, multitracks.com, artistDetails.aspx.
- Finally view artistDetails.aspx and the MultiTracks API in the browser.

Excited for you to see the project! Let me know if you have any questions. 
