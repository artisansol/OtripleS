﻿// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------

using System;
using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using OtripleS.Web.Api.Models.StudentExams;
using Xunit;

namespace OtripleS.Web.Api.Tests.Unit.Services.StudentExams
{
    public partial class StudentExamServiceTests
    {
        [Fact]
        public async Task ShouldAddStudentStudentExamAsync()
        {
            // given
            DateTimeOffset randomDateTime = GetRandomDateTime();
            DateTimeOffset dateTime = randomDateTime;
            StudentExam randomStudentExam = CreateRandomStudentExam(dateTime);
            StudentExam inputStudentExam = randomStudentExam;
            StudentExam storageStudentExam = randomStudentExam;
            StudentExam expectedStudentExam = storageStudentExam;

            this.storageBrokerMock.Setup(broker =>
                broker.InsertStudentExamAsync(inputStudentExam))
                    .ReturnsAsync(storageStudentExam);

            // when
            StudentExam actualStudentExam =
                await this.studentExamService.AddStudentExamAsync(inputStudentExam);

            // then
            actualStudentExam.Should().BeEquivalentTo(expectedStudentExam);

            this.storageBrokerMock.Verify(broker =>
                broker.InsertStudentExamAsync(inputStudentExam),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldRetrieveStudentExamByIdAsync()
        {
            // given
            Guid randomStudentExamId = Guid.NewGuid();
            Guid inputStudentExamId = randomStudentExamId;
            DateTimeOffset randomDateTime = GetRandomDateTime();
            StudentExam randomStudentExam = CreateRandomStudentExam(randomDateTime);
            StudentExam storageStudentExam = randomStudentExam;
            StudentExam expectedStudentExam = storageStudentExam;

            this.storageBrokerMock.Setup(broker =>
                broker.SelectStudentExamByIdAsync(inputStudentExamId))
                    .ReturnsAsync(storageStudentExam);

            // when
            StudentExam actualStudentExam =
                await this.studentExamService.RetrieveStudentExamByIdAsync(inputStudentExamId);

            // then
            actualStudentExam.Should().BeEquivalentTo(expectedStudentExam);

            this.dateTimeBrokerMock.Verify(broker =>
                broker.GetCurrentDateTime(),
                    Times.Never);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectStudentExamByIdAsync(inputStudentExamId),
                    Times.Once);

            this.dateTimeBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
            this.storageBrokerMock.VerifyNoOtherCalls();
        }

        [Fact]
        public async Task ShouldDeleteStudentExamByIdAsync()
        {
            // given
            DateTimeOffset dateTime = GetRandomDateTime();
            StudentExam randomStudentExam = CreateRandomStudentExam(dateTime);
            Guid inputStudentExamId = randomStudentExam.Id;
            StudentExam inputStudentExam = randomStudentExam;
            StudentExam storageStudentExam = inputStudentExam;
            StudentExam expectedStudentExam = storageStudentExam;

            this.storageBrokerMock.Setup(broker =>
                broker.SelectStudentExamByIdAsync(inputStudentExamId))
                    .ReturnsAsync(inputStudentExam);

            this.storageBrokerMock.Setup(broker =>
                broker.DeleteStudentExamAsync(inputStudentExam))
                    .ReturnsAsync(storageStudentExam);

            // when
            StudentExam actualStudentExam =
                await this.studentExamService.DeleteStudentExamByIdAsync(inputStudentExamId);

            //then
            actualStudentExam.Should().BeEquivalentTo(expectedStudentExam);

            this.storageBrokerMock.Verify(broker =>
                broker.SelectStudentExamByIdAsync(inputStudentExamId),
                    Times.Once);

            this.storageBrokerMock.Verify(broker =>
                broker.DeleteStudentExamAsync(inputStudentExam),
                    Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
            this.loggingBrokerMock.VerifyNoOtherCalls();
            this.dateTimeBrokerMock.VerifyNoOtherCalls();
        }
    }
}
