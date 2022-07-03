# SGWebAPI
This is backend API project 

## Cloning repository
- git clone https://github.com/ronaksharma8/SGWebAPI.git
- git checkout master
- cd SGWebAPI


## More about SGWebAPI
- The project is modular in nature as we have separated models, core, service, test into different class library, so that we have be used in another project for code-reuseability / maintainability
- The specification of API can be get via Swagger page i.e. https://localhost:7010/swagger/index.html
- By default, i have configure StatusController to run just to check whether the API is running and UP. This can be useful when running the application in pod to check liveness/ Readines of the application.

- I have added AutoMapper library which creates resultant objects quickly from the source objects. i.e. https://github.com/AutoMapper/AutoMapper
- Additionally, added the server-side pagination feature to display stock list ie. Default pageSize = 50
- In GetAllStock api, we are additionally sending columns(To display stock list) and OrderColumn(To display orders in Basket) to render on client-side. Also, added some attributes too.
  - ColumnOrder :- says which column should come first in grid
  - hidden :- says whether we hide this column on UI
  - QueryProperty :- says whether this column be sortable on UI.  
  - ColumnWidth :- says what should be the width of the column on UI.
  - ColumnName :- says what should be the fieldName for the column defination on UI.
  - Description :- says what should be the headerName for the column defination on UI.
  - ColumnEditable :- says whether the column is editable on UI.
  - ColumnDataType :- says column's DataType on UI.
  

## Authentication

#### Running IdentityServer

- The IdentityServer by default runs on https://localhost:7010
- To check the configuration of it :- https://localhost:7010/.well-known/openid-configuration
- This opens the discovery information of IdentityServer.

## Securing API endpoints
- The endpoints as secured via JWT Bearer token.
- To get the valid access token, import postman collection from "SGWebAPI/SGWebAPI.postman_collection.json" and check "Get Token for react client" postman request
- Put the bearer token into Authorisation header in request call and call the API i.e. check "Get all stock with pagination" and "Post Order"  postman request

## Test project
- We have tested the stockService which is the main service.
- I have used FizzWare.NBuilder to build the test object quickly.. i.e. https://github.com/nbuilder/nbuilder
- I have used FakeItEasy lib for creating mock object i.e. https://github.com/FakeItEasy/FakeItEasy










