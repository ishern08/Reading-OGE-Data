using System.Security.AccessControl;

namespace Reading_OGE_Data;

class Program
{
    static void Main(string[] args)
    {
        string directory = System.AppDomain.CurrentDomain.BaseDirectory;
        string file = Path.Combine(directory, "Francis Tuttle Identities_Basic (1).csv");

        List<EmployeeData> employeeDataList = ReadCSVFile(file);
        if (employeeDataList != null)
        {
            foreach (var employeeData in employeeDataList)
            {
                Console.WriteLine($"Display Name: {employeeData.DisplayName}, First Name: {employeeData.FirstName}, Last Name: {employeeData.LastName}, Work Email: {employeeData.WorkEmail}, Identity ID: {employeeData.IdentityID}, Department: {employeeData.Department}, Job Title: {employeeData.JobTitle}, UID: {employeeData.UID}, Access Type: {employeeData.AccessType}, Access Source Name: {employeeData.AccessSourceName}, Access Display Name: {employeeData.AccessDisplayName}, Access Description: {employeeData.AccessDescription}");
            }
        }

    }



    public static List<EmployeeData> ReadCSVFile(string fileName)
    {
        try
        {
            List<EmployeeData> employeeDataList = new List<EmployeeData>();
            var lines = File.ReadAllLines(fileName);


            for (int i = 1; i < lines.Length; i++)
            {
                var values = lines[i].Split(',');


                EmployeeData employeeData = new EmployeeData
                {
                    DisplayName = values[0].Trim(),
                    FirstName = values[1].Trim(),
                    LastName = values[2].Trim(),
                    WorkEmail = values[3].Trim(),
                    CloudLifecycleState = values[4].Trim().ToLower() == "active" ? true : false,
                    IdentityID = values[5].Trim(),
                    IsManager = values[6].Trim().ToLower() == "yes" ? true : false,
                    Department = values[7].Trim(),
                    JobTitle = values[8].Trim(),
                    UID = values[9].Trim(),
                    AccessType = values[10].Trim(),
                    AccessSourceName = values[11].Trim(),
                    AccessDisplayName = values[12].Trim(),
                    AccessDescription = values[13].Trim(),
                };


                employeeDataList.Add(employeeData);
            }




            return employeeDataList;
        }


        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return null;
        }


    }
}


public struct EmployeeData
    {

        EmployeeData(string displayName, string firstName, string lastName, string workEmail, bool cloudLifecycleState, string identityID,
                            bool isManager, string department, string jobTitle, string uid, string accessType, string accessSourceName, string accessDisplayName, string accessDescription)
        {
            DisplayName = displayName;
            FirstName = firstName;
            LastName = lastName;
            WorkEmail = workEmail;
            CloudLifecycleState = cloudLifecycleState;
            IdentityID = identityID;
            IsManager = isManager;
            Department = department;
            JobTitle = jobTitle;
            UID = uid;
            AccessType = accessType;
            AccessSourceName = accessSourceName;
            AccessDisplayName = accessDisplayName;
            AccessDescription = accessDescription;
        }
        public string DisplayName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string WorkEmail { get; set; }
        public bool CloudLifecycleState { get; set; }
        public string IdentityID { get; set; }
        public bool IsManager { get; set; }
        public string Department { get; set; }
        public string JobTitle { get; set; }
        public string UID { get; set; }
        public string AccessType { get; set; }
        public string AccessSourceName { get; set; }
        public string AccessDisplayName { get; set; }
        public string AccessDescription { get; set; }
    }