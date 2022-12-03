[![.NET](https://github.com/MathewBensonCode/Accounting-C-Sharp/actions/workflows/dotnet.yml/badge.svg)](https://github.com/MathewBensonCode/Accounting-C-Sharp/actions/workflows/dotnet.yml)

# Accounting-C-Sharp

This is an implementation of an accounting application whose purpose is to obtain business source documents, scan them with OCR and obtain the textual representation of the documents. The text data is then to be processed based on regular expressions to classify it and store it in a database.

The Application uses the MVVM pattern. The application flow is controlled with a code first approach where the view models represent views on the actual application. The flow of views is controlled by switching the view models.

This application has mostly been an exercise in Test Driven Development. The idea is to create the application logic using this approach.

## Structure

### AccountsModelCore

 - This sub-project contains the Model Classes that store the actual data to be stored in the database or retrived from the database.

### AccountsEntityFrameworkCore

 - This sub-project contains the code for interacting with the Entity Framework database library


### AccountsViewModel

 - This sub-project contains the code for interacting with the UI using INotifyPropertyChanged, INotifyErrorInfo and other dotnet UI interaction interfaces that are foundational to interacting with dotnet based windows UI libraries

### AccountsViewModelTests

- This sub-project contains the code for testing the classes in the AccountsViewModel project. It uses XUnit and Moq techniques to test the library.
