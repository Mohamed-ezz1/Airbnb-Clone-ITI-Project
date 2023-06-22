using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Airbnb.DAL.Migrations
{
    /// <inheritdoc />
    public partial class v02525 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "Id", "Icon", "Name" },
                values: new object[,]
                {
                    { 1, "https://example.com/icon1.png", "Amenity 1" },
                    { 2, "https://example.com/icon2.png", "Amenity 2" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8d279fcd-143e-4c6c-be8d-ff7860eb239f", 0, "52bd572a-9e2c-4b7f-92e7-dc4e7d9ffa22", null, false, false, null, null, null, null, null, false, "5aab5138-69d2-4e8d-b2c5-dba788b4f312", false, "jane@example.com" },
                    { "c4152243-47ce-4a63-a48a-3396d27640ef", 0, "4b4746ce-1f76-4370-9561-cb6ba9122b77", null, false, false, null, null, null, null, null, false, "1a687dca-c3a9-47e8-af99-546ba4fcbd6f", false, "john@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Category 1" },
                    { 2, "Category 2" }
                });

            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "CountryName" },
                values: new object[,]
                {
                    { 1, "Country 1" },
                    { 2, "Country 2" }
                });

            migrationBuilder.InsertData(
                table: "Rules",
                columns: new[] { "Id", "RuleName" },
                values: new object[,]
                {
                    { 1, "Rule 1" },
                    { 2, "Rule 2" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "CityName", "CounrtyId" },
                values: new object[,]
                {
                    { 1, "City 1", 1 },
                    { 2, "City 2", 1 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "About", "FirstName", "LasttName", "UserType" },
                values: new object[,]
                {
                    { "8d279fcd-143e-4c6c-be8d-ff7860eb239f", "I am an admin user.", "Jane", "Smith", 0 },
                    { "c4152243-47ce-4a63-a48a-3396d27640ef", "I am a regular user.", "John", "Doe", 1 }
                });

            migrationBuilder.InsertData(
                table: "Properties",
                columns: new[] { "Id", "Address", "AvailabilityType", "BathroomCount", "BedCount", "CategoryId", "CityId", "Description", "Latitude", "Longitude", "MaximumNumberOfGuests", "Name", "NumberOfReview", "OverALLReview", "PricePerNight", "RoomCount", "UserId" },
                values: new object[,]
                {
                    { new Guid("7587ebde-9b3a-441b-9b52-44c8364ada20"), "Address 2", true, 1, 2, 2, 2, "Description 2", 12.34m, 45.678m, 4, "Property 2", 0, 0.0, 80.0, 2, "8d279fcd-143e-4c6c-be8d-ff7860eb239f" },
                    { new Guid("a0149e8e-81ae-4213-b847-35c910bc5ed5"), "Address 1", true, 2, 4, 1, 1, "Description 1", 78.90m, 123.456m, 6, "Property 1", 0, 0.0, 100.0, 3, "c4152243-47ce-4a63-a48a-3396d27640ef" }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "Id", "BookingDate", "CheckInDate", "CheckOutDate", "NumberOfGuests", "PropertyId", "TotalPrice", "UserId" },
                values: new object[,]
                {
                    { new Guid("d9e527de-3d4a-404b-9e75-1424d10e0640"), new DateTime(2023, 6, 22, 9, 45, 45, 890, DateTimeKind.Utc).AddTicks(8170), new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Utc), 4, new Guid("a0149e8e-81ae-4213-b847-35c910bc5ed5"), 500.0, "c4152243-47ce-4a63-a48a-3396d27640ef" },
                    { new Guid("ed19e856-c242-43fb-84be-c65db85545ee"), new DateTime(2023, 6, 22, 9, 45, 45, 890, DateTimeKind.Utc).AddTicks(8178), new DateTime(2023, 6, 24, 0, 0, 0, 0, DateTimeKind.Utc), new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Utc), 2, new Guid("7587ebde-9b3a-441b-9b52-44c8364ada20"), 300.0, "8d279fcd-143e-4c6c-be8d-ff7860eb239f" }
                });

            migrationBuilder.InsertData(
                table: "PropertyAmenities",
                columns: new[] { "AmenityId", "PropertyId" },
                values: new object[,]
                {
                    { 2, new Guid("7587ebde-9b3a-441b-9b52-44c8364ada20") },
                    { 1, new Guid("a0149e8e-81ae-4213-b847-35c910bc5ed5") }
                });

            migrationBuilder.InsertData(
                table: "PropertyImages",
                columns: new[] { "Id", "CreatedDate", "Image", "PropertyId", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 22, 12, 45, 45, 890, DateTimeKind.Local).AddTicks(8290), "image1.jpg", new Guid("a0149e8e-81ae-4213-b847-35c910bc5ed5"), "c4152243-47ce-4a63-a48a-3396d27640ef" },
                    { 2, new DateTime(2023, 6, 22, 12, 45, 45, 890, DateTimeKind.Local).AddTicks(8353), "image2.jpg", new Guid("a0149e8e-81ae-4213-b847-35c910bc5ed5"), "8d279fcd-143e-4c6c-be8d-ff7860eb239f" }
                });

            migrationBuilder.InsertData(
                table: "PropertyRules",
                columns: new[] { "PropertyId", "RuleId" },
                values: new object[,]
                {
                    { new Guid("7587ebde-9b3a-441b-9b52-44c8364ada20"), 2 },
                    { new Guid("a0149e8e-81ae-4213-b847-35c910bc5ed5"), 1 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "BookingId", "PropertyId", "UserId", "Comment", "CreatedDate", "Rate" },
                values: new object[,]
                {
                    { new Guid("d9e527de-3d4a-404b-9e75-1424d10e0640"), new Guid("a0149e8e-81ae-4213-b847-35c910bc5ed5"), "c4152243-47ce-4a63-a48a-3396d27640ef", "This property was great!", new DateTime(2023, 6, 22, 9, 45, 45, 890, DateTimeKind.Utc).AddTicks(8187), 4 },
                    { new Guid("ed19e856-c242-43fb-84be-c65db85545ee"), new Guid("7587ebde-9b3a-441b-9b52-44c8364ada20"), "8d279fcd-143e-4c6c-be8d-ff7860eb239f", "Highly recommended!", new DateTime(2023, 6, 22, 9, 45, 45, 890, DateTimeKind.Utc).AddTicks(8268), 5 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PropertyAmenities",
                keyColumns: new[] { "AmenityId", "PropertyId" },
                keyValues: new object[] { 2, new Guid("7587ebde-9b3a-441b-9b52-44c8364ada20") });

            migrationBuilder.DeleteData(
                table: "PropertyAmenities",
                keyColumns: new[] { "AmenityId", "PropertyId" },
                keyValues: new object[] { 1, new Guid("a0149e8e-81ae-4213-b847-35c910bc5ed5") });

            migrationBuilder.DeleteData(
                table: "PropertyImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PropertyImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PropertyRules",
                keyColumns: new[] { "PropertyId", "RuleId" },
                keyValues: new object[] { new Guid("7587ebde-9b3a-441b-9b52-44c8364ada20"), 2 });

            migrationBuilder.DeleteData(
                table: "PropertyRules",
                keyColumns: new[] { "PropertyId", "RuleId" },
                keyValues: new object[] { new Guid("a0149e8e-81ae-4213-b847-35c910bc5ed5"), 1 });

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumns: new[] { "BookingId", "PropertyId", "UserId" },
                keyValues: new object[] { new Guid("d9e527de-3d4a-404b-9e75-1424d10e0640"), new Guid("a0149e8e-81ae-4213-b847-35c910bc5ed5"), "c4152243-47ce-4a63-a48a-3396d27640ef" });

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumns: new[] { "BookingId", "PropertyId", "UserId" },
                keyValues: new object[] { new Guid("ed19e856-c242-43fb-84be-c65db85545ee"), new Guid("7587ebde-9b3a-441b-9b52-44c8364ada20"), "8d279fcd-143e-4c6c-be8d-ff7860eb239f" });

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("d9e527de-3d4a-404b-9e75-1424d10e0640"));

            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "Id",
                keyValue: new Guid("ed19e856-c242-43fb-84be-c65db85545ee"));

            migrationBuilder.DeleteData(
                table: "Rules",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("7587ebde-9b3a-441b-9b52-44c8364ada20"));

            migrationBuilder.DeleteData(
                table: "Properties",
                keyColumn: "Id",
                keyValue: new Guid("a0149e8e-81ae-4213-b847-35c910bc5ed5"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "8d279fcd-143e-4c6c-be8d-ff7860eb239f");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: "c4152243-47ce-4a63-a48a-3396d27640ef");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8d279fcd-143e-4c6c-be8d-ff7860eb239f");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c4152243-47ce-4a63-a48a-3396d27640ef");

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
