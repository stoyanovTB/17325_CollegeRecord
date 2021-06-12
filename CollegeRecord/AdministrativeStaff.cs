using System;

public class AdministrativeStaff : Staff
{
	private bool hasTeachingExperience;
	
	public AdministrativeStaff(int id, string firstName, string lastName, string phoneNumber, string email, string jobTitle, string department, bool isFullTimeStaff, bool hasTeachingExperience) : base(id, firstName, lastName, phoneNumber, email, jobTitle, department, isFullTimeStaff)
	{
		this.hasTeachingExperience = hasTeachingExperience;
	}

	public override string ToString()
	{
		return $"\n\tID: {this.Id}\n\tName: {this.FirstName} {this.LastName}\n\tJob Title: {this.JobTitle}\n\tDepartment: {this.Department}\n\tContact Details:\n\t{this.PhoneNumber}\n\t{this.Email}\n\tFull-Time Staff: {this.IsFullTimeStaff}\n\tTeaching Experience: {this.hasTeachingExperience}\n";
	}
}
