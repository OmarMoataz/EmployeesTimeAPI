using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeTime.Models
{

    public class Metadata
    {
        public string uri { get; set; }
        public string type { get; set; }
    }

    public class Deferred
    {
        public string uri { get; set; }
    }

    public class CountryExtensionCOL
    {
        public Deferred __deferred { get; set; }
    }

    public class Deferred2
    {
        public string uri { get; set; }
    }

    public class RecurrenceGroupNav
    {
        public Deferred2 __deferred { get; set; }
    }

    public class Deferred3
    {
        public string uri { get; set; }
    }

    public class TimeCalendar
    {
        public Deferred3 __deferred { get; set; }
    }

    public class Deferred4
    {
        public string uri { get; set; }
    }

    public class TimeTypeNav
    {
        public Deferred4 __deferred { get; set; }
    }

    public class Deferred5
    {
        public string uri { get; set; }
    }

    public class CountryExtensionESP
    {
        public Deferred5 __deferred { get; set; }
    }

    public class Deferred6
    {
        public string uri { get; set; }
    }

    public class WfRequestNav
    {
        public Deferred6 __deferred { get; set; }
    }

    public class Deferred7
    {
        public string uri { get; set; }
    }

    public class CustAttachmentNav
    {
        public Deferred7 __deferred { get; set; }
    }

    public class Deferred8
    {
        public string uri { get; set; }
    }

    public class ApprovalStatusNav
    {
        public Deferred8 __deferred { get; set; }
    }

    public class Deferred9
    {
        public string uri { get; set; }
    }

    public class CountryExtensionDEU
    {
        public Deferred9 __deferred { get; set; }
    }

    public class Deferred10
    {
        public string uri { get; set; }
    }

    public class CountryExtensionMEX
    {
        public Deferred10 __deferred { get; set; }
    }

    public class Deferred11
    {
        public string uri { get; set; }
    }

    public class MdfSystemStatusNav
    {
        public Deferred11 __deferred { get; set; }
    }

    public class Deferred12
    {
        public string uri { get; set; }
    }

    public class TimeRecordOriginNav
    {
        public Deferred12 __deferred { get; set; }
    }

    public class Deferred13
    {
        public string uri { get; set; }
    }

    public class CustDeliverytypeNav
    {
        public Deferred13 __deferred { get; set; }
    }

    public class Deferred14
    {
        public string uri { get; set; }
    }

    public class CreatedByNav
    {
        public Deferred14 __deferred { get; set; }
    }

    public class Deferred15
    {
        public string uri { get; set; }
    }

    public class MdfSystemRecordStatusNav
    {
        public Deferred15 __deferred { get; set; }
    }

    public class Deferred16
    {
        public string uri { get; set; }
    }

    public class UserIdNav
    {
        public Deferred16 __deferred { get; set; }
    }

    public class Result
    {
        public Metadata __metadata { get; set; }
        public string externalCode { get; set; }
        public string quantityInDays { get; set; }
        public string mdfSystemObjectType { get; set; }
        public object cancellationWorkflowRequestId { get; set; }
        public DateTime endDate { get; set; }
        public DateTime lastModifiedDateTime { get; set; }
        public object endTime { get; set; }
        public string timeType { get; set; }
        public object cust_deliverytype { get; set; }
        public object startTime { get; set; }
        public string mdfSystemRecordId { get; set; }
        public string mdfSystemEntityId { get; set; }
        public string userId { get; set; }
        public string fractionQuantity { get; set; }
        public string approvalStatus { get; set; }
        public string mdfSystemStatus { get; set; }
        public object cust_expectedweek { get; set; }
        public DateTime createdDate { get; set; }
        public bool undeterminedEndDate { get; set; }
        public string mdfSystemRecordStatus { get; set; }
        public bool workflowInitiatedByAdmin { get; set; }
        public bool editable { get; set; }
        public string createdBy { get; set; }
        public DateTime createdDateTime { get; set; }
        public string lastModifiedBy { get; set; }
        public object loaExpectedReturnDate { get; set; }
        public DateTime mdfSystemEffectiveStartDate { get; set; }
        public object comment { get; set; }
        public object loaStartJobInfoId { get; set; }
        public DateTime startDate { get; set; }
        public DateTime mdfSystemEffectiveEndDate { get; set; }
        public object mdfSystemVersionId { get; set; }
        public object recurrenceGroup { get; set; }
        public string mdfSystemTransactionSequence { get; set; }
        public object timeRecordOrigin { get; set; }
        public object workflowRequestId { get; set; }
        public string displayQuantity { get; set; }
        public object loaActualReturnDate { get; set; }
        public DateTime lastModifiedDateWithTZ { get; set; }
        public string quantityInHours { get; set; }
        public bool flexibleRequesting { get; set; }
        public string deductionQuantity { get; set; }
        public object loaEndJobInfoId { get; set; }
        public string originalQuantityInDays { get; set; }
        public DateTime lastModifiedDate { get; set; }
        public object cust_notificationdate { get; set; }
        public CountryExtensionCOL countryExtensionCOL { get; set; }
        public RecurrenceGroupNav recurrenceGroupNav { get; set; }
        public TimeCalendar timeCalendar { get; set; }
        public TimeTypeNav timeTypeNav { get; set; }
        public CountryExtensionESP countryExtensionESP { get; set; }
        public WfRequestNav wfRequestNav { get; set; }
        public CustAttachmentNav cust_attachmentNav { get; set; }
        public ApprovalStatusNav approvalStatusNav { get; set; }
        public CountryExtensionDEU countryExtensionDEU { get; set; }
        public CountryExtensionMEX countryExtensionMEX { get; set; }
        public MdfSystemStatusNav mdfSystemStatusNav { get; set; }
        public TimeRecordOriginNav timeRecordOriginNav { get; set; }
        public CustDeliverytypeNav cust_deliverytypeNav { get; set; }
        public CreatedByNav createdByNav { get; set; }
        public MdfSystemRecordStatusNav mdfSystemRecordStatusNav { get; set; }
        public UserIdNav userIdNav { get; set; }
    }

    public class D
    {
        public List<Result> results { get; set; }
    }

    public class RootObject
    {
        public D d { get; set; }
    }
}
