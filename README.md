# Fynx Automation Project

An automated testing project for the Fynx application using Selenium WebDriver.

## Project Description

This project automates UI testing for the Fynx application. It includes automated tests for key features such as login, registration, user profile management, feed updates, and categories.

## Technologies

- **C# / .NET 8.0** - Programming language
- **Selenium WebDriver 4.39.0** - UI automation
- **MSTest** - Testing framework
- **ExcelDataReader 3.8.0** - Reading test data from Excel files
- **ChromeDriver** - Chrome driver for Selenium

## Project Structure

```
Fynx-Automation-project/
├── Tests/                    # Test suite folder
│   ├── BaseTest.cs          # Base test class with Setup/Teardown
│   ├── LoginTests.cs        # Login tests
│   ├── RegistrationTests.cs # Registration tests
│   ├── ProfileTests.cs      # User profile tests
│   ├── FeedTests.cs         # Feed tests
│   ├── CategoryTests.cs     # Category tests
│   └── ApiTests.cs          # API tests
├── Pages/                    # Page Object Model
│   ├── BasePage.cs          # Base page class
│   ├── LoginPage.cs         # Login page
│   ├── RegistrationPage.cs  # Registration page
│   ├── ProfilePage.cs       # Profile page
│   ├── FeedPage.cs          # Feed page
│   ├── CategoriesPage.cs    # Categories page
│   └── WelcomePage.cs       # Welcome page
├── Data/                     # Test data
│   ├── TestData.xlsx        # Test data in Excel file
│   └── profile.jpg          # Profile image for testing
├── ExcelHelper.cs           # Excel reading utility
└── FynxAutomationProject.csproj
```

## Getting Started

### Prerequisites

- .NET 8.0 SDK
- Google Chrome installed
- ChromeDriver compatible with your Chrome version

### Installation

1. Clone the repository:
```bash
git clone <repository-url>
cd Fynx-Automation-project
```

2. Install dependencies:
```bash
dotnet restore
```

### Running Tests

Run all tests:
```bash
dotnet test
```

Run specific tests:
```bash
dotnet test --filter "ClassName=LoginTests"
```

Run with verbose output:
```bash
dotnet test --logger "console;verbosity=detailed"
```

## Test Data

Test data is stored in `Data/TestData.xlsx`. The file contains registration details and login credentials for testing.

### Reading Test Data
```csharp
var testData = ExcelHelper.GetRegistrationData("Data/TestData.xlsx");
```

## Page Object Model

The project uses the Page Object Model design pattern to organize and maintain test code.

Example:
```csharp
public class LoginPage : BasePage
{
    // Locators
    private By emailInput = By.Id("email");
    private By passwordInput = By.Id("password");

    // Actions
    public void Login(string email, string password)
    {
        driver.FindElement(emailInput).SendKeys(email);
        driver.FindElement(passwordInput).SendKeys(password);
    }
}
```

## Test Example

```csharp
[TestClass]
public class LoginTests : BaseTest
{
    [TestMethod]
    public void LoginWithValidCredentials()
    {
        // Arrange
        var loginPage = new LoginPage(driver);

        // Act
        loginPage.Login("test@example.com", "password123");

        // Assert
        Assert.IsTrue(driver.Title.Contains("Dashboard"));
    }
}
```

## Configuration

- **Base URL**: `http://localhost:4200`
- **Implicit Wait**: 10 seconds
- **Browser**: Chrome

## Available Tests

- **LoginTests** - Login tests (with valid and invalid credentials)
- **RegistrationTests** - New user registration tests
- **ProfileTests** - User profile update tests
- **FeedTests** - Feed display and management tests
- **CategoryTests** - Feed category tests
- **ApiTests** - API endpoint tests

## Tips

- Ensure the Fynx application is running on `http://localhost:4200` before running tests
- Check that ChromeDriver is compatible with your Chrome version
- Verify Excel test data before running registration tests

## Support

For more information or questions, contact the project maintainers.

## License

This project is part of a business automation course.
