using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Rockaway.WebApp.Migrations {
	/// <inheritdoc />
	public partial class TicketTypesAndVenueCultures : Migration {
		/// <inheritdoc />
		protected override void Up(MigrationBuilder migrationBuilder) {
			migrationBuilder.DropColumn(
				name: "CountryCode",
				table: "Venue");

			migrationBuilder.AddColumn<string>(
				name: "CultureName",
				table: "Venue",
				type: "nvarchar(max)",
				nullable: false,
				defaultValue: "");

			migrationBuilder.CreateTable(
				name: "Show",
				columns: table => new {
					Date = table.Column<DateTime>(type: "datetime2", nullable: false),
					VenueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					HeadlineArtistId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_Show", x => new { x.VenueId, x.Date });
					table.ForeignKey(
						name: "FK_Show_Artist_HeadlineArtistId",
						column: x => x.HeadlineArtistId,
						principalTable: "Artist",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
					table.ForeignKey(
						name: "FK_Show_Venue_VenueId",
						column: x => x.VenueId,
						principalTable: "Venue",
						principalColumn: "Id",
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.CreateTable(
				name: "TicketType",
				columns: table => new {
					Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
					ShowVenueId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
					ShowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
					Price = table.Column<decimal>(type: "money", nullable: false)
				},
				constraints: table => {
					table.PrimaryKey("PK_TicketType", x => x.Id);
					table.ForeignKey(
						name: "FK_TicketType_Show_ShowVenueId_ShowDate",
						columns: x => new { x.ShowVenueId, x.ShowDate },
						principalTable: "Show",
						principalColumns: new[] { "VenueId", "Date" },
						onDelete: ReferentialAction.Cascade);
				});

			migrationBuilder.UpdateData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: "rockaway-sample-admin-user",
				columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
				values: new object[] { "3c260f39-4c9e-42e9-bd0f-b0b38015fb18", "AQAAAAIAAYagAAAAEA8Buka69G/vWCW/MRRoG3fqnLIObPSajFvmK1kj/woZzA5/pvWAbdJCtwqLHMsiVw==", "58549eb6-2ef6-4c10-90fb-dc31ef0af2e0" });

			migrationBuilder.InsertData(
				table: "Show",
				columns: new[] { "Date", "VenueId", "HeadlineArtistId" },
				values: new object[,]
				{
					{ new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb2"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4") },
					{ new DateTime(2023, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb3"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4") },
					{ new DateTime(2023, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb4"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4") },
					{ new DateTime(2023, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb5"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4") },
					{ new DateTime(2023, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb7"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4") },
					{ new DateTime(2023, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb8"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4") },
					{ new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb9"), new Guid("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaa4") }
				});

			migrationBuilder.UpdateData(
				table: "Venue",
				keyColumn: "Id",
				keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb1"),
				column: "CultureName",
				value: "en-GB");

			migrationBuilder.UpdateData(
				table: "Venue",
				keyColumn: "Id",
				keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb2"),
				column: "CultureName",
				value: "fr-FR");

			migrationBuilder.UpdateData(
				table: "Venue",
				keyColumn: "Id",
				keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb3"),
				column: "CultureName",
				value: "de-DE");

			migrationBuilder.UpdateData(
				table: "Venue",
				keyColumn: "Id",
				keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb4"),
				column: "CultureName",
				value: "el-GR");

			migrationBuilder.UpdateData(
				table: "Venue",
				keyColumn: "Id",
				keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb5"),
				column: "CultureName",
				value: "nb-NO");

			migrationBuilder.UpdateData(
				table: "Venue",
				keyColumn: "Id",
				keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb6"),
				column: "CultureName",
				value: "dk-DK");

			migrationBuilder.UpdateData(
				table: "Venue",
				keyColumn: "Id",
				keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb7"),
				column: "CultureName",
				value: "pt-PT");

			migrationBuilder.UpdateData(
				table: "Venue",
				keyColumn: "Id",
				keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb8"),
				column: "CultureName",
				value: "sv-SE");

			migrationBuilder.UpdateData(
				table: "Venue",
				keyColumn: "Id",
				keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb9"),
				column: "CultureName",
				value: "en-GB");

			migrationBuilder.InsertData(
				table: "TicketType",
				columns: new[] { "Id", "Name", "Price", "ShowDate", "ShowVenueId" },
				values: new object[,]
				{
					{ new Guid("4886d0a8-f8a8-473a-a5e7-feb24e7f91a9"), "General Admission", 35m, new DateTime(2023, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb3") },
					{ new Guid("541fb9a6-678c-4cef-9244-d76de44910bc"), "VIP Meet & Greet", 55m, new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb9") },
					{ new Guid("5c39b8cd-e620-48d9-bbdd-056bf95cdca4"), "VIP Meet & Greet", 75m, new DateTime(2023, 10, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb3") },
					{ new Guid("6e087259-395d-4721-834e-5aa5d472eef9"), "General Admission", 300m, new DateTime(2023, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb8") },
					{ new Guid("6e139d3a-1299-4e0e-9ad6-b9c2dfaaa792"), "General Admission", 25m, new DateTime(2023, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb9") },
					{ new Guid("702e5852-e4c1-4150-87b8-3f752e7276d2"), "VIP Meet & Greet", 75m, new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb2") },
					{ new Guid("70a797d5-4fb5-4f3f-9154-6e51b9e7d239"), "General Admission", 35m, new DateTime(2023, 10, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb2") },
					{ new Guid("97c06545-73fc-4fcd-8b2c-d1e71c5fe704"), "VIP Meet & Greet", 720m, new DateTime(2023, 10, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb8") },
					{ new Guid("a5bc0691-656c-43f0-9e78-085edc98100c"), "VIP Meet & Greet", 750m, new DateTime(2023, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb5") },
					{ new Guid("afb8b2cf-bc0f-4e60-a67e-b2d40c1b3550"), "General Admission", 350m, new DateTime(2023, 10, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb5") },
					{ new Guid("c878ce66-7d7e-4e23-b153-bc885ae42ede"), "General Admission", 25m, new DateTime(2023, 10, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb7") },
					{ new Guid("f540f8bd-ea3b-49ce-b753-e4158c17986f"), "General Admission", 25m, new DateTime(2023, 10, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb4") }
				});

			migrationBuilder.CreateIndex(
				name: "IX_Show_HeadlineArtistId",
				table: "Show",
				column: "HeadlineArtistId");

			migrationBuilder.CreateIndex(
				name: "IX_TicketType_ShowVenueId_ShowDate",
				table: "TicketType",
				columns: new[] { "ShowVenueId", "ShowDate" });
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder) {
			migrationBuilder.DropTable(
				name: "TicketType");

			migrationBuilder.DropTable(
				name: "Show");

			migrationBuilder.DropColumn(
				name: "CultureName",
				table: "Venue");

			migrationBuilder.AddColumn<string>(
				name: "CountryCode",
				table: "Venue",
				type: "varchar(2)",
				unicode: false,
				maxLength: 2,
				nullable: false,
				defaultValue: "");

			migrationBuilder.UpdateData(
				table: "AspNetUsers",
				keyColumn: "Id",
				keyValue: "rockaway-sample-admin-user",
				columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
				values: new object[] { "5a254f57-ad9f-43b4-b405-38d756a98a55", "AQAAAAIAAYagAAAAEHKVlYe/Wiagre6rrsh3+c9HWfl8gpaZZ0EqOYB5mrE8lU3Z9XGeIxUhri/j9uFg6Q==", "5a5eab5c-abde-4038-998f-b0ce7a584392" });

			migrationBuilder.UpdateData(
				table: "Venue",
				keyColumn: "Id",
				keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb1"),
				column: "CountryCode",
				value: "GB");

			migrationBuilder.UpdateData(
				table: "Venue",
				keyColumn: "Id",
				keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb2"),
				column: "CountryCode",
				value: "FR");

			migrationBuilder.UpdateData(
				table: "Venue",
				keyColumn: "Id",
				keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb3"),
				column: "CountryCode",
				value: "DE");

			migrationBuilder.UpdateData(
				table: "Venue",
				keyColumn: "Id",
				keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb4"),
				column: "CountryCode",
				value: "GR");

			migrationBuilder.UpdateData(
				table: "Venue",
				keyColumn: "Id",
				keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb5"),
				column: "CountryCode",
				value: "NO");

			migrationBuilder.UpdateData(
				table: "Venue",
				keyColumn: "Id",
				keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb6"),
				column: "CountryCode",
				value: "DK");

			migrationBuilder.UpdateData(
				table: "Venue",
				keyColumn: "Id",
				keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb7"),
				column: "CountryCode",
				value: "PT");

			migrationBuilder.UpdateData(
				table: "Venue",
				keyColumn: "Id",
				keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb8"),
				column: "CountryCode",
				value: "SE");

			migrationBuilder.UpdateData(
				table: "Venue",
				keyColumn: "Id",
				keyValue: new Guid("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbb9"),
				column: "CountryCode",
				value: "GB");
		}
	}
}