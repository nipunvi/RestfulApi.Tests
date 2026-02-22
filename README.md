RESTful API AUTOMATION FRAMEWORK

This project is a C#  based Test Automation Framework with Xunit test runner to validate CRUD operations of https://restful-api.dev/ endpoints.


FEATURES 

1. Language : C#
2. Test Runner : xUnit
3. Handled JSON : System.Text.Json
4. Architecture :  Seperated concernes between Models(data structure), Clients (Logics) and Tests (Assertions or validations)


PROJECT FOLDER/FILE STRUCTURE

RestfullAPI.Test/
├── Config/
│   └-- ConfigData.json      # URLs and Test Data
├── Models/
│   ├-- ConfigData.cs        # C# mapping for config data
│   ├-- ObjectData.cs        # API Request/Response data models
│   └-- DeleteResponse.cs    # Model for delete confirmation response
├── Clients/
│   └-- APIClient.cs         # Reusable logics for HTTP methods
└── RestAPITests.cs          # Testcases (CRUD scenarios)


RUNNING TESTS

Using Visual Studio:
1. Open the Test Explorer.
2. Click Run All.

Using Command Line:
1. dotnet test


TEST SCENARIOS 

1. Get All Objects: Validates the API successfully returns a list of objects.
2. Add Object: Creates a new device and captures the unique ID.
3. Get by ID: Verifies the newly created device can be retrieved.
4. Update Object: Modifies device details and validates the update timestamp.
5. Delete Object: Removes the device and verifies the success message.
6. Negative Validation: Confirms the object is no longer available after deletion

