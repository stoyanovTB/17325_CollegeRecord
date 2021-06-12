using System;

public abstract class Staff
{
    private int id;
    private string firstName;
    private string lastName;
	private string phoneNumber;
	private string email;
	private string jobTitle;
	private string department;
	private bool isFullTimeStaff;

    public int Id { get => id; set => id = value; }
    public string FirstName { get => firstName; set => firstName = value; }
    public string LastName { get => lastName; set => lastName = value; }
    public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
    public string Email { get => email; set => email = value; }
    public string JobTitle { get => jobTitle; set => jobTitle = value; }
    public string Department { get => department; set => department = value; }
    public bool IsFullTimeStaff { get => isFullTimeStaff; set => isFullTimeStaff = value; }

    public Staff()
	{

	}

	public Staff(int id, string firstName, string lastName, string phoneNumber, string email, string jobTitle, string department, bool isFullTimeStaff)
	{
		this.Id = id;
		this.FirstName = firstName;
		this.LastName = lastName;
	    this.PhoneNumber = phoneNumber;
		this.Email = email;
		this.JobTitle = jobTitle;
		this.Department = department;
		this.IsFullTimeStaff = isFullTimeStaff;
	}
}
