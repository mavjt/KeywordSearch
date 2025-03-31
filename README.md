# KeywordSearch

This project is a development project created to show programming knowledge.

I used a .NET 8 backend with React frontend.  The database is SQL Express.

Given the restriction of not using a third party library, I chose to use Regex for matching results, but normally I would use Html Agility Pack.
Adverts, enriched results and "People also ask" are treated as part of the normal results and affect index numbers accordingly.    

I was unable to get the code working against the google search engine.  They appear to have put something in place that stops their search results page being called from code.  I tried to use Postman and also Fiddler to monitor the requests, but didn't see any request that returned HTML with results in.  
Simple requests return a consent screen only which then requires a browser to properly get past.  Requests visible in a browser Network tab seem to suggest they do some redirects and use cookies/tokens to block their site from non-browser traffic.
Because of this, I have mocked up an example html page from using the browser to do a search in google.  this is stored in the root of KeywordSearch.Server and any search the project does against the Google search engine, will only use this file.  

Bing was move forgiving although I was blocked a few times and had to swap servers on my VPN.   

No AI generated code was used in this project.