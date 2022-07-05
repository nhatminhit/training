
    //--------------------------------------------------------------------------------------
    // 1. Naming - Đặt tên 
    //--------------------------------------------------------------------------------------

    //--------------------------------------------------------------------------------------
    // Tránh sử dụng tên không rõ nghĩa
    // Bad
    int d;
    // Good
    int daySinceModification;


    //--------------------------------------------------------------------------------------
    // Tránh sử dụng tên gây hiểu lầm khi đọc code 
    // Bad
    var dataFromDb = db.GetFromService().ToList();
    // Good
    var listOfEmployee = _employeeService.GetEmployees().ToList();


    //--------------------------------------------------------------------------------------
    // Tránh sử dụng Hungarian Notation cho C# .NET 
    // Bad
    int iCounter;
    string strFullName;
    DateTime dModifiedDate;
    public bool IsShopOpen(string pDay, int pAmount)
    {
        // some logic
    }
    // Good
    int counter;
    string fullName;
    DateTime modifiedDate;
    public bool IsShopOpen(string day, int amount)
    {
        // some logic
    }


    //--------------------------------------------------------------------------------------
    // Nhất quán trong việc viết hoa 
    // Bad
    const int DAYS_IN_WEEK = 7;
    const int daysInMonth = 30;

    var songs = new List<string> { 'Back In Black', 'Stairway to Heaven', 'Hey Jude' };
    var Artists = new List<string> { 'ACDC', 'Led Zeppelin', 'The Beatles' };

    bool EraseDatabase() { }
    bool Restore_database() { }

    class animal { }
    class Alpaca { }
    // Good
    const int DaysInWeek = 7;
    const int DaysInMonth = 30;

    var songs = new List<string> { 'Back In Black', 'Stairway to Heaven', 'Hey Jude' };
    var artists = new List<string> { 'ACDC', 'Led Zeppelin', 'The Beatles' };

    bool EraseDatabase() { }
    bool RestoreDatabase() { }

    class Animal { }
    class Alpaca { }


    //--------------------------------------------------------------------------------------
    // Đặt tên biến có ý nghĩa 
    // Bad
    public class Employee
    {
        public Datetime sWorkDate { get; set; } // what the heck is this
        public Datetime modTime { get; set; } // same here
    }
    // Good
    public class Employee
    {
        public Datetime StartWorkingDate { get; set; }
        public Datetime ModificationTime { get; set; }
    }

    //--------------------------------------------------------------------------------------
    // Sử dụng CamelCase cho tên biến cục bộ và các params 
    // Bad
    var employeephone;
    public double CalculateSalary(int workingdays, int workinghours)
    {
        // some logic
    }
    // Good
    var employeePhone;
    public double CalculateSalary(int workingDays, int workingHours)
    {
        // some logic
    }

    //--------------------------------------------------------------------------------------
    // Viết code theo chuẩn mà các lập trình viên khác có thể dễ dàng đọc hiểu mà ko cần giải thích 
    // Good
    public class SingleObject
    {
        // create an object of SingleObject
        private static SingleObject _instance = new SingleObject();

        // make the constructor private so that this class cannot be instantiated
        private SingleObject() { }

        // get the only object available
        public static SingleObject GetInstance()
        {
            return _instance;
        }

        public string ShowMessage()
        {
            return "Hello World!";
        }
    }

    public static void main(String[] args)
    {
        // illegal construct
        // var object = new SingleObject();

        // Get the only object available
        var singletonObject = SingleObject.GetInstance();

        // show the message
        singletonObject.ShowMessage();
    }


//--------------------------------------------------------------------------------------
// 2. Variables - Biến  
//--------------------------------------------------------------------------------------

//--------------------------------------------------------------------------------------
// Return kết quả càng sớm càng tốt 
// Bad
public bool IsShopOpen(string day)
{
    if (!string.IsNullOrEmpty(day))
    {
        day = day.ToLower();
        if (day == "friday")
        {
            return true;
        }
        else if (day == "saturday")
        {
            return true;
        }
        else if (day == "sunday")
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    else
    {
        return false;
    }

}

public long Fibonacci(int n)
{
    if (n < 50)
    {
        if (n != 0)
        {
            if (n != 1)
            {
                return Fibonacci(n - 1) + Fibonacci(n - 2);
            }
            else
            {
                return 1;
            }
        }
        else
        {
            return 0;
        }
    }
    else
    {
        throw new System.Exception("Not supported");
    }
}
// Good
public bool IsShopOpen(string day)
{
    if (string.IsNullOrEmpty(day))
    {
        return false;
    }

    var openingDays = new[] { "friday", "saturday", "sunday" };
    return openingDays.Any(d => d == day.ToLower());
}

public long Fibonacci(int n)
{
    if (n == 0)
    {
        return 0;
    }

    if (n == 1)
    {
        return 1;
    }

    if (n > 50)
    {
        throw new System.Exception("Not supported");
    }

    return Fibonacci(n - 1) + Fibonacci(n - 2);
}

//--------------------------------------------------------------------------------------
// Tránh đặt tên biến một cách chung chung không rõ nghĩa  
// Bad
var l = new[] { "Austin", "New York", "San Francisco" };

for (var i = 0; i < l.Count(); i++)
{
    var li = l[i];
    DoStuff();
    DoSomeOtherStuff();

    // ...
    // ...
    // ...
    // Wait, what is `li` for again?
    Dispatch(li);
}
// Good
var locations = new[] { "Austin", "New York", "San Francisco" };

foreach (var location in locations)
{
    DoStuff();
    DoSomeOtherStuff();

    // ...
    // ...
    // ...
    Dispatch(location);
}


//--------------------------------------------------------------------------------------
// Tránh các magic string
// Bad
if (userRole == "Admin")
{
    // logic in here
}
// Good
const string ADMIN_ROLE = "Admin";
if (userRole == ADMIN_ROLE)
{
    // logic in here
}

//--------------------------------------------------------------------------------------
// Tránh việc lặp lại tên class trong tên các biến hoặc phương thức 
// Bad
public class Car
{
    public string CarMake { get; set; }
    public string CarModel { get; set; }
    public string CarColor { get; set; }

    //...
}
// Good
public class Car
{
    public string Make { get; set; }
    public string Model { get; set; }
    public string Color { get; set; }

    //...
}


//--------------------------------------------------------------------------------------
// Đặt tên biến một cách có ý nghĩa và có thể phát âm được  
// Bad
var ymdstr = DateTime.UtcNow.ToString("MMMM dd, yyyy");
// Good
var currentDate = DateTime.UtcNow.ToString("MMMM dd, yyyy");


//--------------------------------------------------------------------------------------
// Sử dụng cùng một từ vựng cho cùng một loại biến   
// Bad
GetUserInfo();
GetUserData();
GetUserRecord();
GetUserProfile();
// Good
GetUser();


//--------------------------------------------------------------------------------------
// Đặt tên biến có thể tìm kiếm được 
// Bad
// What the heck is data for?
var data = new { Name = "John", Age = 42 };

var stream1 = new MemoryStream();
var ser1 = new DataContractJsonSerializer(typeof(object));
ser1.WriteObject(stream1, data);

stream1.Position = 0;
var sr1 = new StreamReader(stream1);
Console.Write("JSON form of Data object: ");
Console.WriteLine(sr1.ReadToEnd());

var data = new { Name = "John", Age = 42, PersonAccess = 4 };

// What the heck is 4 for?
if (data.PersonAccess == 4)
{
    // do edit ...
}
// Good
var person = new Person
{
    Name = "John",
    Age = 42
};

var stream2 = new MemoryStream();
var ser2 = new DataContractJsonSerializer(typeof(Person));
ser2.WriteObject(stream2, data);

stream2.Position = 0;
var sr2 = new StreamReader(stream2);
Console.Write("JSON form of Data object: ");
Console.WriteLine(sr2.ReadToEnd());

public enum PersonAccess : int
{
    ACCESS_READ = 1,
    ACCESS_CREATE = 2,
    ACCESS_UPDATE = 4,
    ACCESS_DELETE = 8
}

var person = new Person
{
    Name = "John",
    Age = 42,
    PersonAccess = PersonAccess.ACCESS_CREATE
};

if (person.PersonAccess == PersonAccess.ACCESS_UPDATE)
{
    // do edit ...
}


//--------------------------------------------------------------------------------------
// Đặt tên biến có sự hàm chứa giải thích trong đó  
// Bad
const string Address = "One Infinite Loop, Cupertino 95014";
var cityZipCodeRegex = @"/^[^,\]+[,\\s]+(.+?)\s*(\d{5})?$/";
var matches = Regex.Matches(Address, cityZipCodeRegex);
if (matches[0].Success == true && matches[1].Success == true)
{
    SaveCityZipCode(matches[0].Value, matches[1].Value);
}
// Good
const string Address = "One Infinite Loop, Cupertino 95014";
var cityZipCodeWithGroupRegex = @"/^[^,\]+[,\\s]+(?<city>.+?)\s*(?<zipCode>\d{5})?$/";
var matchesWithGroup = Regex.Match(Address, cityZipCodeWithGroupRegex);
var cityGroup = matchesWithGroup.Groups["city"];
var zipCodeGroup = matchesWithGroup.Groups["zipCode"];
if (cityGroup.Success == true && zipCodeGroup.Success == true)
{
    SaveCityZipCode(cityGroup.Value, zipCodeGroup.Value);
}


//--------------------------------------------------------------------------------------
// Sử dụng các default parameters thay vì kiểm tra điều kiện 
// Bad
public void CreateMicrobrewery(string name = null)
{
    var breweryName = !string.IsNullOrEmpty(name) ? name : "Hipster Brew Co.";
    // ...
}
// Good
public void CreateMicrobrewery(string breweryName = "Hipster Brew Co.")
{
    // ...
}

//--------------------------------------------------------------------------------------
// 3. Function - Hàm   
//--------------------------------------------------------------------------------------


//--------------------------------------------------------------------------------------
// Tránh side effects 
// Bad
// Global variable referenced by following function.
// If we had another function that used this name, now it'd be an array and it could break it.
var name = 'Ryan McDermott';

public string SplitIntoFirstAndLastName()
{
    return name.Split(" ");
}

SplitIntoFirstAndLastName();

Console.PrintLine(name); // ['Ryan', 'McDermott'];
// Good
public string SplitIntoFirstAndLastName(string name)
{
    return name.Split(" ");
}

var name = 'Ryan McDermott';
var newName = SplitIntoFirstAndLastName(name);

Console.PrintLine(name); // 'Ryan McDermott';
Console.PrintLine(newName); // ['Ryan', 'McDermott'];


//--------------------------------------------------------------------------------------
// Tránh điều kiện negative false 
// Bad
public bool IsDOMNodeNotPresent(string node)
{
    // ...
}

if (!IsDOMNodeNotPresent(node))
{
    // ...
}
// Good
public bool IsDOMNodePresent(string node)
{
    // ...
}

if (IsDOMNodePresent(node))
{
    // ...
}

//--------------------------------------------------------------------------------------
// Hạn chế dùng điều kiện mà thay vào đó hãy dùng kế thừa  
// Bad
class Airplane
{
    // ...

    public double GetCruisingAltitude()
    {
        switch (_type)
        {
            case '777':
                return GetMaxAltitude() - GetPassengerCount();
            case 'Air Force One':
                return GetMaxAltitude();
            case 'Cessna':
                return GetMaxAltitude() - GetFuelExpenditure();
        }
    }
}
// Good
interface IAirplane
{
    // ...

    double GetCruisingAltitude();
}

class Boeing777 : IAirplane
{
    // ...

    public double GetCruisingAltitude()
    {
        return GetMaxAltitude() - GetPassengerCount();
    }
}

class AirForceOne : IAirplane
{
    // ...

    public double GetCruisingAltitude()
    {
        return GetMaxAltitude();
    }
}

class Cessna : IAirplane
{
    // ...

    public double GetCruisingAltitude()
    {
        return GetMaxAltitude() - GetFuelExpenditure();
    }
}


//--------------------------------------------------------------------------------------
// Tránh kiểm tra kiểu dữ liệu 
// Bad
public Path TravelToTexas(object vehicle)
{
    if (vehicle.GetType() == typeof(Bicycle))
    {
        (vehicle as Bicycle).PeddleTo(new Location("texas"));
    }
    else if (vehicle.GetType() == typeof(Car))
    {
        (vehicle as Car).DriveTo(new Location("texas"));
    }
}

public int Combine(dynamic val1, dynamic val2)
{
    int value;
    if (!int.TryParse(val1, out value) || !int.TryParse(val2, out value))
    {
        throw new Exception('Must be of type Number');
    }

    return val1 + val2;
}

// Good
public Path TravelToTexas(Traveler vehicle)
{
    vehicle.TravelTo(new Location("texas"));
}

// pattern matching
public Path TravelToTexas(object vehicle)
{
    if (vehicle is Bicycle bicycle)
    {
        bicycle.PeddleTo(new Location("texas"));
    }
    else if (vehicle is Car car)
    {
        car.DriveTo(new Location("texas"));
    }
}

public int Combine(int val1, int val2)
{
    return val1 + val2;
}

//--------------------------------------------------------------------------------------
// Tránh đặt các cờ kiểu bool trong parameters
// Bad
public void CreateFile(string name, bool temp = false)
{
    if (temp)
    {
        Touch("./temp/" + name);
    }
    else
    {
        Touch(name);
    }
}
// Good
public void CreateFile(string name)
{
    Touch(name);
}

public void CreateTempFile(string name)
{
    Touch("./temp/" + name);
}


//--------------------------------------------------------------------------------------
// Không được write vào các hàm toàn cục 
// Bad
public string[] Config()
{
    return  [
        "foo" => "bar",
    ]
}
// Good
class Configuration
{
    private string[] _configuration = [];

    public Configuration(string[] configuration)
    {
        _configuration = configuration;
    }

    public string[] Get(string key)
    {
        return (_configuration[key] != null) ? _configuration[key] : null;
    }
}
// Load configuration and create instance of Configuration class
var configuration = new Configuration(new string[] {
    "foo" => "bar",
});


//--------------------------------------------------------------------------------------
// Hạn chế sử dụng Singleton thay vào đó hãy dùng options 
// Bad
class DBConnection
{
    private static DBConnection _instance;

    private DBConnection()
    {
        // ...
    }

    public static GetInstance()
    {
        if (_instance == null)
        {
            _instance = new DBConnection();
        }

        return _instance;
    }

    // ...
}

var singleton = DBConnection.GetInstance();
// Good
class DBConnection
{
    public DBConnection(IOptions<DbConnectionOption> options)
    {
        // ...
    }

    // ...
}
// Create instance of DBConnection class and configure it with Option pattern.
var options = < resolve from IOC>;
var connection = new DBConnection(options);


//--------------------------------------------------------------------------------------
// Nên sử dụng tối đa 2 parameters cho một hàm  
// Bad
public void CreateMenu(string title, string body, string buttonText, bool cancellable)
{
    // ...
}
// Good
pubic class MenuConfig
{
    public string Title { get; set; }
    public string Body { get; set; }
    public string ButtonText { get; set; }
    public bool Cancellable { get; set; }
}

var config = new MenuConfig
{
    Title = "Foo",
    Body = "Bar",
    ButtonText = "Baz",
    Cancellable = true
};

public void CreateMenu(MenuConfig config)
{
    // ...
}


//--------------------------------------------------------------------------------------
// Một hàm nên và chỉ nên làm một nhiệm vụ duy nhất 
// Bad
public void SendEmailToListOfClients(string[] clients)
{
    foreach (var client in clients)
    {
        var clientRecord = db.Find(client);
        if (clientRecord.IsActive())
        {
            Email(client);
        }
    }
}
// Good
public void SendEmailToListOfClients(string[] clients)
{
    var activeClients = GetActiveClients(clients);
    // Do some logic
}

public List<Client> GetActiveClients(string[] clients)
{
    return db.Find(clients).Where(s => s.Status == "Active");
}


//--------------------------------------------------------------------------------------
// Đặt tên hàm theo mục đích rõ ràng  
// Bad
public class Email
{
    //...

    public void Handle()
    {
        SendMail(this._to, this._subject, this._body);
    }
}

var message = new Email(...);
// What is this? A handle for the message? Are we writing to a file now?
message.Handle();
// Good
public class Email
{
    //...

    public void Send()
    {
        SendMail(this._to, this._subject, this._body);
    }
}

var message = new Email(...);
// Clear and obvious
message.Send();

//--------------------------------------------------------------------------------------
// Functions should only be one level of abstraction
// Bad
public string ParseBetterJSAlternative(string code)
{
    var regexes = [
        // ...
    ];

    var statements = explode(" ", code);
    var tokens = new string[] { };
    foreach (var regex in regexes)
    {
        foreach (var statement in statements)
        {
            // ...
        }
    }

    var ast = new string[] { };
    foreach (var token in tokens)
    {
        // lex...
    }

    foreach (var node in ast)
    {
        // parse...
    }
}
// Good
class Tokenizer
{
    public string Tokenize(string code)
    {
        var regexes = new string[] {
            // ...
        };

        var statements = explode(" ", code);
        var tokens = new string[] { };
        foreach (var regex in regexes)
        {
            foreach (var statement in statements)
            {
                tokens[] = /* ... */;
            }
        }

        return tokens;
    }
}

class Lexer
{
    public string Lexify(string[] tokens)
    {
        var ast = new[] { };
        foreach (var token in tokens)
        {
            ast[] = /* ... */;
        }

        return ast;
    }
}

class BetterJSAlternative
{
    private string _tokenizer;
    private string _lexer;

    public BetterJSAlternative(Tokenizer tokenizer, Lexer lexer)
    {
        _tokenizer = tokenizer;
        _lexer = lexer;
    }

    public string Parse(string code)
    {
        var tokens = _tokenizer.Tokenize(code);
        var ast = _lexer.Lexify(tokens);
        foreach (var node in ast)
        {
            // parse...
        }
    }
}


//--------------------------------------------------------------------------------------
// Các hàm callers và callees nên đặt gần nhau 
// Bad
class PerformanceReview
{
    private readonly Employee _employee;

    public PerformanceReview(Employee employee)
    {
        _employee = employee;
    }

    private IEnumerable<PeersData> LookupPeers()
    {
        return db.lookup(_employee, 'peers');
    }

    private ManagerData LookupManager()
    {
        return db.lookup(_employee, 'manager');
    }

    private IEnumerable<PeerReviews> GetPeerReviews()
    {
        var peers = LookupPeers();
        // ...
    }

    public PerfReviewData PerfReview()
    {
        GetPeerReviews();
        GetManagerReview();
        GetSelfReview();
    }

    public ManagerData GetManagerReview()
    {
        var manager = LookupManager();
    }

    public EmployeeData GetSelfReview()
    {
        // ...
    }
}

var review = new PerformanceReview(employee);
review.PerfReview();
// Good
class PerformanceReview
{
    private readonly Employee _employee;

    public PerformanceReview(Employee employee)
    {
        _employee = employee;
    }

    public PerfReviewData PerfReview()
    {
        GetPeerReviews();
        GetManagerReview();
        GetSelfReview();
    }

    private IEnumerable<PeerReviews> GetPeerReviews()
    {
        var peers = LookupPeers();
        // ...
    }

    private IEnumerable<PeersData> LookupPeers()
    {
        return db.lookup(_employee, 'peers');
    }

    private ManagerData GetManagerReview()
    {
        var manager = LookupManager();
        return manager;
    }

    private ManagerData LookupManager()
    {
        return db.lookup(_employee, 'manager');
    }

    private EmployeeData GetSelfReview()
    {
        // ...
    }
}

var review = new PerformanceReview(employee);
review.PerfReview();


//--------------------------------------------------------------------------------------
// Nên gom các biểu thức điều kiện và tách thành hàm riêng
// Bad
if (article.state == "published")
{
    // ...
}
// Good
if (article.IsPublished())
{
    // ...
}



//--------------------------------------------------------------------------------------
// Xóa hết các code không dùng 
// Bad
public void OldRequestModule(string url)
{
    // ...
}

public void NewRequestModule(string url)
{
    // ...
}

var request = NewRequestModule(requestUrl);
InventoryTracker("apples", request, "www.inventory-awesome.io");
// Good
public void RequestModule(string url)
{
    // ...
}

var request = RequestModule(requestUrl);
InventoryTracker("apples", request, "www.inventory-awesome.io");

//--------------------------------------------------------------------------------------
// 5. Objects, Data Structures, Classes  - Đối tượng, cấu trúc dữ liệu, lớp 
//--------------------------------------------------------------------------------------

//--------------------------------------------------------------------------------------
// Sử dụng getters và setters 
// Bad
class BankAccount
{
    public double Balance = 1000;
}

var bankAccount = new BankAccount();

// Fake buy shoes...
bankAccount.Balance -= 100;
// Good
class BankAccount
{
    private double _balance = 0.0D;

    pubic double Balance
    {
        get
        {
            return _balance;
        }
    }

    public BankAccount(balance = 1000)
    {
        _balance = balance;
    }

    public void WithdrawBalance(int amount)
    {
        if (amount > _balance)
        {
            throw new Exception('Amount greater than available balance.');
        }

        _balance -= amount;
    }

    public void DepositBalance(int amount)
    {
        _balance += amount;
    }
}

var bankAccount = new BankAccount();

// Buy shoes...
bankAccount.WithdrawBalance(price);

// Get balance
balance = bankAccount.Balance;


//--------------------------------------------------------------------------------------
// Hạn chế tối đa public setters 
// Bad
class Employee
{
    public string Name { get; set; }

    public Employee(name)
    {
        Name = name;
    }
}
// Good
class Employee
{
    public string Name { get; }

    public Employee(string name)
    {
        Name = name;
    }
}

//--------------------------------------------------------------------------------------
// Sử dụng các method chaining 
// Bad

// Good
public static class ListExtensions
{
    public static List<T> FluentAdd<T>(this List<T> list, T item)
    {
        list.Add(item);
        return list;
    }

    public static List<T> FluentClear<T>(this List<T> list)
    {
        list.Clear();
        return list;
    }

    public static List<T> FluentForEach<T>(this List<T> list, Action<T> action)
    {
        list.ForEach(action);
        return list;
    }

    public static List<T> FluentInsert<T>(this List<T> list, int index, T item)
    {
        list.Insert(index, item);
        return list;
    }

    public static List<T> FluentRemoveAt<T>(this List<T> list, int index)
    {
        list.RemoveAt(index);
        return list;
    }

    public static List<T> FluentReverse<T>(this List<T> list)
    {
        list.Reverse();
        return list;
    }
}

internal static void ListFluentExtensions()
{
    var list = new List<int>() { 1, 2, 3, 4, 5 }
        .FluentAdd(1)
        .FluentInsert(0, 0)
        .FluentRemoveAt(1)
        .FluentReverse()
        .FluentForEach(value => value.WriteLine())
        .FluentClear();
}


//--------------------------------------------------------------------------------------
// Khuyến khích dùng composition thay vì kế thừa 
// Bad
class Employee
{
    private string Name { get; set; }
    private string Email { get; set; }

    public Employee(string name, string email)
    {
        Name = name;
        Email = email;
    }

    // ...
}

// Bad because Employees "have" tax data.
// EmployeeTaxData is not a type of Employee

class EmployeeTaxData : Employee
{
    private string Name { get; }
    private string Email { get; }

    public EmployeeTaxData(string name, string email, string ssn, string salary)
    {
        // ...
    }

    // ...
}
// Good
class EmployeeTaxData
{
    public string Ssn { get; }
    public string Salary { get; }

    public EmployeeTaxData(string ssn, string salary)
    {
        Ssn = ssn;
        Salary = salary;
    }

    // ...
}

class Employee
{
    public string Name { get; }
    public string Email { get; }
    public EmployeeTaxData TaxData { get; }

    public Employee(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public void SetTax(string ssn, double salary)
    {
        TaxData = new EmployeeTaxData(ssn, salary);
    }

    // ...
}


//--------------------------------------------------------------------------------------
// 4. Error Handling - Xử lý lỗi   
//--------------------------------------------------------------------------------------

//--------------------------------------------------------------------------------------
// Không "throw ex" in khối catch 
// Bad
try
{
    // Do something..
}
catch (Exception ex)
{
    // Any action something like roll-back or logging etc.
    throw ex;
}
// Good
try
{
    // Do something..
}
catch (Exception ex)
{
    // Any action something like roll-back or logging etc.
    throw;
}

//--------------------------------------------------------------------------------------
// Tuyệt đối không nên bỏ qua các lỗi 
// Bad
try
{
    FunctionThatMightThrow();
}
catch (Exception ex)
{
    // silent exception
}
// Good
try
{
    FunctionThatMightThrow();
}
catch (Exception error)
{
    NotifyUserOfError(error);

    // Another option
    ReportErrorToService(error);
}

//--------------------------------------------------------------------------------------
// Sử dụng nhiều mức catch thay vì dùng điều kiện if
// Bad
try
{
    // Do something..
}
catch (Exception ex)
{

    if (ex is TaskCanceledException)
    {
        // Take action for TaskCanceledException
    }
    else if (ex is TaskSchedulerException)
    {
        // Take action for TaskSchedulerException
    }
}
// Good
try
{
    // Do something..
}
catch (TaskCanceledException ex)
{
    // Take action for TaskCanceledException
}
catch (TaskSchedulerException ex)
{
    // Take action for TaskSchedulerException
}


//--------------------------------------------------------------------------------------
// Keep exception stack trace when rethrowing exceptions
// Bad
try
{
    FunctionThatMightThrow();
}
catch (Exception ex)
{
    logger.LogInfo(ex);
    throw ex;
}
// Good
try
{
    FunctionThatMightThrow();
}
catch (Exception error)
{
    logger.LogInfo(error);
    throw;
}

try
{
    FunctionThatMightThrow();
}
catch (Exception error)
{
    logger.LogInfo(error);
    throw new CustomException(error);
}
