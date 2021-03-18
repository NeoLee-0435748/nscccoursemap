using System;
using System.ComponentModel.DataAnnotations;

// Ref: https://itqna.net/questions/5249/dataannotations-checking-between-start-time-and-end-time
namespace NsccCourseMap.Models
{
  public class CompareTwoDates : ValidationAttribute
  {
    private string DateToCompareFieldName { get; set; }

    public CompareTwoDates(string dateToCompareFieldName)
    {
      DateToCompareFieldName = dateToCompareFieldName;
    }

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
      DateTime laterDate = (DateTime)value;
      DateTime earlierDate = (DateTime)validationContext
        .ObjectType
        .GetProperty(DateToCompareFieldName)
        .GetValue(validationContext.ObjectInstance, null);

      if (laterDate > earlierDate)
      {
        return ValidationResult.Success;
      }
      else
      {
        return new ValidationResult(
          string.Format("{0} should be earlier than other!", DateToCompareFieldName));
      }
    }
  }
}