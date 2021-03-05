﻿//---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
//----------------------------------------------------------------

using System.Linq;
using System.Threading.Tasks;
using OtripleS.Web.Api.Models.AssignmentAttachments;

namespace OtripleS.Web.Api.Services.AssignmentAttachments
{
    public interface IAssignmentAttachmentService
    {
        ValueTask<AssignmentAttachment> AddAssignmentAttachmentAsync(AssignmentAttachment assignmentAttachment);
        IQueryable<AssignmentAttachment> RetrieveAllAssignmentAttachments();
    }
}