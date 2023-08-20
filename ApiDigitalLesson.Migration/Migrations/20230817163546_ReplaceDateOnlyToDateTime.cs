using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiDigitalLesson.Migration.Migrations
{
    public partial class ReplaceDateOnlyToDateTime : Microsoft.EntityFrameworkCore.Migrations.Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("0535648d-481f-40fe-a381-256af47acb97"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("055ad00b-014d-446f-831f-9132bf6fabc6"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("0930de0c-aa1b-4ddd-8fc6-3141d9acf862"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("0d501443-fc1c-4740-8381-6dcd951817d1"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("10cfe1f7-1a1e-4ae5-9c50-408bbdfecbbb"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("114c4e97-fac3-49af-8944-591a27b7800d"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("142cbf52-4dba-45f8-8fab-65225db5f4d0"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("1ce190c0-33df-4416-90ee-64e0b84f5021"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("1df79adb-356c-4188-9561-f3c48e793f45"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("1df8b4f9-fb75-408b-96d0-cd6eaa78b0d7"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("24fa9a3a-9a81-43b4-b86b-9319924c328d"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("25817e1a-0e6f-44bb-a11c-7e1e2a12343e"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("259039d5-8c60-4956-9f7b-fc45ed7bb359"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("282e1f6f-8a45-4b93-89d5-6d6ac33de3f7"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("288b07e1-9286-4363-85db-4fcd924302ae"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("29afff99-286c-4f22-b8a2-f0c36b2c3213"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("29de8143-1496-4959-b121-89e2e78659f1"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("2b7d7819-e50a-4d15-ae65-60a76d2eb2a2"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("2ce7a3ff-c7e4-43f4-81d9-c3dd7902e262"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("30fbbe08-dc29-4e7e-9e07-a7e5680a9a5f"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("314fb244-951b-4a33-9862-c05a722bc220"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("317240f9-a92e-49e2-b151-d048678939ec"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("35873033-c65a-4307-bfd3-3aad386a8813"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("364728c7-7241-438f-832a-a8a9ccdde1b1"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("38dcd820-498a-473c-a96d-f7b59f7847b9"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("38e7e148-b27d-4746-b2ef-e62bad5b541b"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("3a6e4d78-b82f-4057-b50d-dcdc35aaa5ac"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("3b0d52b4-4921-46d2-aa65-fb1cd36b8f92"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("3ec952c0-bc6f-42a2-912d-4b7c3ee91e2a"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("409c2801-79e4-4f01-aa8b-a574de3fc98c"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("415faa0d-f144-4111-a20d-3f1a48f66ae4"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("429a8148-1daa-4e9f-9a56-f690c8a36dec"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("42d1121f-5621-4d22-adf2-fe363e675870"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("44022d48-263c-4ecd-98eb-02068761df16"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("44df0387-4298-4135-aeb9-9f4c8b0138c7"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("4953f4ea-91f1-4168-9f53-e83bf909f572"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("4a3e98ab-6fdf-4db0-831f-872b68a7836b"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("4b7249ea-71ed-4e15-aabc-48c63a731644"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("4c03b5f3-5d6f-4e7e-a155-b6f41801fb50"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("4c52f4a3-e327-418b-b639-3dd7c0c57d6d"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("4d1d9eab-47fa-4c9b-ba32-fa230fc82342"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("4f6dbab8-a7c6-46da-b3eb-cb83a64506b7"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("4f7c6d4e-2e9f-45ab-968f-79778c340f75"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("4fb68591-cd10-4d7a-b0cd-9ff6b453f564"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("53850ab0-5adf-475c-bd3c-b510cfe93642"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("56563072-ebec-4d76-81c6-10aa20534119"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("5996ad85-e770-4f2e-a50d-cacfe4d2ae77"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("59c2eb7c-7626-4102-9844-043c5669aafd"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("5d66f0c1-2754-42c8-8b52-3246c96518d0"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("5e2b2f23-071e-4423-9bf8-3a68b1f959f9"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("6578b2d1-579f-4c47-97d3-e0a32e945360"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("677e9784-1f3e-47dc-abc7-e93eeb546e1d"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("68ac1ad8-002d-4186-bfc8-ebd5acf684e7"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("69935247-5ce7-48de-adc3-9111c89cf5fb"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("6a65c0cc-202c-421b-85f3-4557a8638593"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("6b82965d-6973-4e3a-a379-8e76ab0b7a5d"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("6cad4673-8c94-461e-8a7b-f8e9303fe7df"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("6fdb06b3-2b31-4a47-b0bf-11fb04737dad"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("71899516-dca4-4653-a359-44dd2dc1d771"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("74de6b9a-51a5-410a-ba6f-3ce713b5a367"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("767d7d86-d85f-476d-a503-591dadace88e"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("76f19ee7-4aef-4a14-950d-83df7ace10e8"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("79cb6116-a9ae-43ac-898f-c737a4fdfbfa"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("7ae2bdaf-4e70-4c54-9240-53c46e183f01"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("7baef7c1-054c-435a-9447-9171c8d9adf9"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("7e8512ea-95d5-4abb-ad4e-8ac23bfd2bd8"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("7f821cce-12b4-4ecc-8f2c-ed679a96aa83"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("80b25906-463d-4ff5-9315-28d0103320c3"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("827231ba-2a43-4471-9a49-272c442c3a46"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("862ae15c-e91f-4b1a-ac29-7589f804674e"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("8709c8e0-1ec1-44cf-917f-a95060477501"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("8711b9e3-19f0-4129-8c9e-d209066efd83"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("89513895-9af6-42f1-baed-347fad64a0d1"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("8e1ad3a9-25ae-4649-b4ca-ab5643d306f4"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("97e97f1c-2e66-42d3-b1cf-bf6700b33cf0"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("9a349dc6-cf9a-415c-9187-7e8056f9c4ee"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("9f902c9c-2a8b-4d11-a71d-c096c0aee3dd"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("a0c4b74b-6557-436c-9f04-6f21284fdbcb"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("a19e9168-e103-4542-bd4f-5a956b5c5231"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("a30c0908-727e-47cb-937e-6d23c728c6a2"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("a331929e-ff62-4f01-85a9-32fa52792ba7"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("ae96a6b2-0fca-4a04-b7a0-b2a17b43544b"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("b288ffd4-1c6a-4731-9954-99a1e655983f"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("b34bfec0-4d10-4d07-9cca-c90513dafd33"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("b5758162-2c91-44b4-b85c-0dcc03702f9e"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("b76a53a9-2e29-4b63-b4c5-ca02c9267da2"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("befceccd-d521-497a-a3c9-3cb489982472"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("befebe1c-7383-4659-9e79-4b11df9f8e99"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("c08eeaf2-93e0-41df-b74b-cd4aa9e49f87"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("ca4b47ab-706e-433a-aa02-4651352a2759"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("ca82733f-3b73-49f0-8d43-6e5ce70b61d7"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("cb1d5053-22cb-4d11-b10e-8a2a9a2ccaae"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("d059a026-2dbf-41e4-a472-f1521125f2ed"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("d2b8db87-cb3f-4195-a9bb-99cf1d421d77"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("d49d7557-8965-4bda-a636-8658c5e32390"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("d5261858-74aa-490c-b724-b8d623aea4e7"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("d8f39c26-420b-4c98-949d-0f5abf2d7026"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("da8b5860-609d-4bab-b41e-6472425b58c0"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("dceb8cbd-d618-4f34-9ba7-091f464249d6"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("dfa9e0d3-3d28-433e-898d-5f35e571ac0d"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("e0bc384c-3f28-4f74-8019-3ba28d54b191"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("e1c552d1-bf81-463e-b762-cc8afee9a3b7"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("e56be609-d5c2-4581-add4-93015fb733b7"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("e5f001cd-f68a-4341-b000-f2c4079542d3"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("e7b6612d-5452-4197-b2fc-e310c8eb1d51"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("e936fb76-e12a-4ddd-89e0-1186a6584ed2"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("ec612445-d7c1-4e62-a56d-8ead4427b393"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("ec71c836-faff-4e67-b515-95685d75980b"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("ed5f00ab-1612-485b-9fd9-7d9538c81a69"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("efeef0fe-3a1f-47e4-9e1c-bc3f86163a98"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("f0a8882b-d601-466b-b01c-218d5795e998"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("f4d40764-d8d4-4c46-a8de-f8bf30a97ee1"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("f6efba9d-77ef-4d81-817c-f4cad911fad2"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("f73712ba-235f-4715-b12b-f904ad54b3be"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("f87b8b38-b6bd-4675-b3c4-529d7e254ca6"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("f92002f0-c83a-4cc7-a052-c8b001f848bd"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("f9650001-705f-4c07-be6b-b6ac970141e0"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("fb441322-364a-4e6a-be55-754b1c2f5f8b"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("fbd51f73-ded0-4e2a-b38a-1d34913d91df"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("fbf31ae2-9660-4de7-be60-06bb2385feea"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("0a282dac-7f68-4b64-b178-0b311d5c89a4"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("14050398-947e-45ef-b869-90e7f39b354c"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("41e925dd-a86c-4a5a-8a90-976aca725251"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("75c2c708-c285-4122-a427-0dac7be4e3bf"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("a95fa4bc-5438-463f-89b4-bccc5970f978"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("f9527b95-fdf5-4319-9397-8d2aa964e39c"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("ea0dc2c3-3b1a-45a0-b899-8ea58959596a"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateBirthday",
                table: "Teacher",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateBirthday",
                table: "Students",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.InsertData(
                table: "TypeLessons",
                columns: new[] { "Id", "Category", "Description", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("01a91034-5e58-4b58-89c2-faf062eed3d7"), 1, null, "ОГЭ", null },
                    { new Guid("2b3132bf-cf29-4569-a9a3-19528b3f6196"), 6, null, "Школьная программа", null },
                    { new Guid("47116702-7301-4d25-ba45-6a16d13ae109"), 4, null, "Гуманитарные науки", null },
                    { new Guid("75d35df9-b838-4101-8c38-1e5c27e24fbf"), 3, null, "Естественные науки", null },
                    { new Guid("99548a47-fb5b-40c0-914f-0bbf259e3484"), 2, null, "Технические науки", null },
                    { new Guid("a8f28f88-ebc5-4314-9c15-f2b9602a191e"), 0, null, "ЕГЭ", null },
                    { new Guid("aaf4967f-d0fb-4c07-b812-a2d90ebf7d6f"), 8, null, "Искусство", null },
                    { new Guid("ca6835b0-4cf4-4cc7-84dd-49a0596950e8"), 5, null, "Программирование", null },
                    { new Guid("e671eaf1-f68e-476b-ba99-bc946f3a99b8"), 7, null, "Музыка", null }
                });

            migrationBuilder.InsertData(
                table: "TypeLessons",
                columns: new[] { "Id", "Category", "Description", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("00fb379e-aa17-45b5-8294-eecee2f63735"), null, null, "Французский язык", new Guid("a8f28f88-ebc5-4314-9c15-f2b9602a191e") },
                    { new Guid("1102b1bc-0309-4c6c-bf9b-affa5e29df65"), null, null, "Математика", new Guid("01a91034-5e58-4b58-89c2-faf062eed3d7") },
                    { new Guid("165c2d31-2bec-4a6e-aa3a-c5b9ea4667af"), null, null, "1-4 класс", new Guid("2b3132bf-cf29-4569-a9a3-19528b3f6196") },
                    { new Guid("16ae6f71-87d5-4a5c-a688-862e5b972ee9"), null, null, "Обществознание", new Guid("a8f28f88-ebc5-4314-9c15-f2b9602a191e") },
                    { new Guid("23221583-4e31-44f1-a345-863ba3515a09"), null, null, "Русский язык", new Guid("a8f28f88-ebc5-4314-9c15-f2b9602a191e") },
                    { new Guid("292b7f75-1092-4827-9b49-5d87d4d7f4d8"), null, null, "Французский язык", new Guid("01a91034-5e58-4b58-89c2-faf062eed3d7") },
                    { new Guid("2d0132a8-3960-4600-9fa2-d591a3366936"), null, null, "История", new Guid("01a91034-5e58-4b58-89c2-faf062eed3d7") },
                    { new Guid("3ad52ae2-df87-499b-b2a0-7f4f8e2929e4"), null, null, "История", new Guid("a8f28f88-ebc5-4314-9c15-f2b9602a191e") },
                    { new Guid("3c245e00-0a8a-4fad-8778-2f51ab8a7078"), null, null, "Китайский язык", new Guid("a8f28f88-ebc5-4314-9c15-f2b9602a191e") },
                    { new Guid("46ed4923-40a3-4ab9-9efd-f4ad111f4f6a"), null, null, "Английский язык", new Guid("01a91034-5e58-4b58-89c2-faf062eed3d7") },
                    { new Guid("485b1dbf-63fd-4409-80ea-c68474ca4625"), null, null, "География", new Guid("a8f28f88-ebc5-4314-9c15-f2b9602a191e") },
                    { new Guid("6dd3c2bd-c704-49a4-9560-15c8e2c2c47c"), null, null, "Русский язык", new Guid("01a91034-5e58-4b58-89c2-faf062eed3d7") },
                    { new Guid("6fa48385-d664-4a57-889a-4dd82a9ce6f4"), null, null, "Народные языки", new Guid("2b3132bf-cf29-4569-a9a3-19528b3f6196") },
                    { new Guid("71c6e33d-bbf0-43de-89d1-4c3655887ebf"), null, null, "Испанский язык", new Guid("01a91034-5e58-4b58-89c2-faf062eed3d7") },
                    { new Guid("84ad7bb2-effd-49d1-b0a1-2ad49680cf4a"), null, null, "Физика", new Guid("01a91034-5e58-4b58-89c2-faf062eed3d7") },
                    { new Guid("855d7ca0-3e41-4ff0-816b-0e8aa83d9863"), null, null, "Литература", new Guid("01a91034-5e58-4b58-89c2-faf062eed3d7") },
                    { new Guid("8d32acd2-c31a-4666-8569-ffde5d353709"), null, null, "География", new Guid("01a91034-5e58-4b58-89c2-faf062eed3d7") },
                    { new Guid("8ee5a3f5-9e7d-4234-9a1c-33da7f4e561b"), null, null, "Немецкий язык", new Guid("a8f28f88-ebc5-4314-9c15-f2b9602a191e") },
                    { new Guid("a044e007-8b86-453a-87d3-552e0f812da5"), null, null, "Биология", new Guid("01a91034-5e58-4b58-89c2-faf062eed3d7") },
                    { new Guid("a5136936-6e3f-4bfc-bc57-0dab989c734e"), null, null, "Литература", new Guid("a8f28f88-ebc5-4314-9c15-f2b9602a191e") },
                    { new Guid("a67d3ed3-cf97-4aa3-9a2b-a89ada98cdfb"), null, null, "Немецкий язык", new Guid("01a91034-5e58-4b58-89c2-faf062eed3d7") },
                    { new Guid("ad8387c8-75c0-45e3-8252-1fb5d6f5a38b"), null, null, "Информатика", new Guid("01a91034-5e58-4b58-89c2-faf062eed3d7") },
                    { new Guid("b856ae56-a5a3-4edf-a1a5-c8b47348ae95"), null, null, "Математика (базовый уровень)", new Guid("a8f28f88-ebc5-4314-9c15-f2b9602a191e") },
                    { new Guid("be4df5a7-8741-43ee-9157-d58ee14237b8"), null, null, "Химия", new Guid("a8f28f88-ebc5-4314-9c15-f2b9602a191e") },
                    { new Guid("bf485cf7-f4f2-47ed-8aa9-387238efc878"), null, null, "Биология", new Guid("a8f28f88-ebc5-4314-9c15-f2b9602a191e") },
                    { new Guid("c1952e80-3eaa-40a4-ba80-75e4e17571c1"), null, null, "Физика", new Guid("a8f28f88-ebc5-4314-9c15-f2b9602a191e") },
                    { new Guid("c1fc8f18-655e-4ccc-8eae-fdf2ce4659e9"), null, null, "Информатика", new Guid("a8f28f88-ebc5-4314-9c15-f2b9602a191e") },
                    { new Guid("c8f70d8d-f10d-4b0f-afe8-3ecc0b56db33"), null, null, "9-11 класс", new Guid("2b3132bf-cf29-4569-a9a3-19528b3f6196") },
                    { new Guid("d4e34dfe-3863-40dd-bf2b-de11e6985cfd"), null, null, "Китайский язык", new Guid("01a91034-5e58-4b58-89c2-faf062eed3d7") },
                    { new Guid("d605bec7-2b98-4860-9cf4-a688d2550fb0"), null, null, "Испанский язык", new Guid("a8f28f88-ebc5-4314-9c15-f2b9602a191e") },
                    { new Guid("d78a0d39-cdc0-4ec6-9077-d411379ecd96"), null, null, "География", new Guid("01a91034-5e58-4b58-89c2-faf062eed3d7") },
                    { new Guid("df5c6151-d5e7-4d66-91b4-53c3c4e9e9d4"), null, null, "Английский язык", new Guid("a8f28f88-ebc5-4314-9c15-f2b9602a191e") },
                    { new Guid("dfc96a33-2d44-45ff-af8e-26c36780f41e"), null, null, "Химия", new Guid("01a91034-5e58-4b58-89c2-faf062eed3d7") },
                    { new Guid("e22d7336-4ead-44cc-bf4d-90b73a0e924a"), null, null, "Обществознание", new Guid("01a91034-5e58-4b58-89c2-faf062eed3d7") },
                    { new Guid("e54ae0a3-2373-4899-83dc-76e91993c194"), null, null, "Математика (профильный уровень)", new Guid("a8f28f88-ebc5-4314-9c15-f2b9602a191e") },
                    { new Guid("fda5cce1-d62a-40da-a41f-045dce2ec9af"), null, null, "5-9 класс", new Guid("2b3132bf-cf29-4569-a9a3-19528b3f6196") },
                    { new Guid("fee5977c-07a8-4aa0-af63-63b7ee22bac4"), null, null, "География", new Guid("a8f28f88-ebc5-4314-9c15-f2b9602a191e") }
                });

            migrationBuilder.InsertData(
                table: "TypeLessons",
                columns: new[] { "Id", "Category", "Description", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("04aa1506-33a2-4cda-a71f-aea2ee0e93c4"), null, null, "Технология", new Guid("fda5cce1-d62a-40da-a41f-045dce2ec9af") },
                    { new Guid("07f2dbc4-87ea-4aa1-bb4a-76e788b6a3b3"), null, null, "Всеобщая история", new Guid("c8f70d8d-f10d-4b0f-afe8-3ecc0b56db33") },
                    { new Guid("0d2607db-83f9-4802-8823-b0c29dab4e3b"), null, null, "Литературное чтение", new Guid("165c2d31-2bec-4a6e-aa3a-c5b9ea4667af") },
                    { new Guid("164fcc6b-709f-4447-8b14-5882dcbcb142"), null, null, "Технология", new Guid("165c2d31-2bec-4a6e-aa3a-c5b9ea4667af") },
                    { new Guid("1ed64895-d942-4ef1-a66f-ba487472374d"), null, null, "Математика", new Guid("165c2d31-2bec-4a6e-aa3a-c5b9ea4667af") },
                    { new Guid("1f02d0e2-906f-4ac4-90ba-130abb83edfd"), null, null, "Информатика", new Guid("fda5cce1-d62a-40da-a41f-045dce2ec9af") },
                    { new Guid("1f2b1cc2-f7ba-4958-8c64-dd1d17100aa9"), null, null, "Окружающий мир", new Guid("165c2d31-2bec-4a6e-aa3a-c5b9ea4667af") },
                    { new Guid("2006004c-5bf4-4c3a-8569-1cf6616fc3bb"), null, null, "Физическая культура", new Guid("fda5cce1-d62a-40da-a41f-045dce2ec9af") },
                    { new Guid("235a8b7c-6d0a-4784-8f99-5f604d6b7aa9"), null, null, "Ингушский язык", new Guid("6fa48385-d664-4a57-889a-4dd82a9ce6f4") },
                    { new Guid("253d3b7e-2bd1-40d0-a16a-32b139591a5c"), null, null, "Обществознание", new Guid("fda5cce1-d62a-40da-a41f-045dce2ec9af") },
                    { new Guid("2ecfc2da-130e-434c-8cc7-208aafd97782"), null, null, "Музыка", new Guid("165c2d31-2bec-4a6e-aa3a-c5b9ea4667af") },
                    { new Guid("32af3f53-50f7-48b0-b41e-8c110490a136"), null, null, "Калмыцкий язык", new Guid("6fa48385-d664-4a57-889a-4dd82a9ce6f4") },
                    { new Guid("344ee67f-b13d-4cae-97d5-1f56019afa88"), null, null, "Китайский язык", new Guid("165c2d31-2bec-4a6e-aa3a-c5b9ea4667af") },
                    { new Guid("34cde938-537d-4005-80ac-98a028c543b6"), null, null, "Алтайский язык", new Guid("6fa48385-d664-4a57-889a-4dd82a9ce6f4") },
                    { new Guid("38beb114-7099-48b9-b574-b8a5c21ddbc5"), null, null, "Башкирский язык", new Guid("6fa48385-d664-4a57-889a-4dd82a9ce6f4") },
                    { new Guid("3909e559-b3e9-4d2c-ae18-3c9731aca6a2"), null, null, "Биология", new Guid("fda5cce1-d62a-40da-a41f-045dce2ec9af") },
                    { new Guid("3a544249-e594-49f2-a373-fcd171a6f201"), null, null, "Осетинский язык", new Guid("6fa48385-d664-4a57-889a-4dd82a9ce6f4") },
                    { new Guid("431c6ba3-bc64-4035-9869-f8308405dedb"), null, null, "Основы религиозных культур и светской этики", new Guid("fda5cce1-d62a-40da-a41f-045dce2ec9af") },
                    { new Guid("45d2636b-b287-4ecb-b5dc-c630c161de3b"), null, null, "Хакасский язык", new Guid("6fa48385-d664-4a57-889a-4dd82a9ce6f4") },
                    { new Guid("4684cfc8-ab0c-4652-b6a3-ef2b805ce55e"), null, null, "Английский язык", new Guid("fda5cce1-d62a-40da-a41f-045dce2ec9af") },
                    { new Guid("46aebcb7-b754-48ac-9ca5-689e282ed1a9"), null, null, "Немецкий язык", new Guid("c8f70d8d-f10d-4b0f-afe8-3ecc0b56db33") },
                    { new Guid("481141ff-1107-4cdf-a9d6-607e546c5f40"), null, null, "Физика", new Guid("c8f70d8d-f10d-4b0f-afe8-3ecc0b56db33") },
                    { new Guid("490a1d6e-2523-4b90-b23b-8b9020d4ad72"), null, null, "Русский язык", new Guid("165c2d31-2bec-4a6e-aa3a-c5b9ea4667af") },
                    { new Guid("4c06cd4f-183b-41ef-b05d-40d2c6ed2a84"), null, null, "Французский язык", new Guid("165c2d31-2bec-4a6e-aa3a-c5b9ea4667af") },
                    { new Guid("4eaa8de0-9468-4f42-961b-a9fe4d22ca79"), null, null, "География", new Guid("fda5cce1-d62a-40da-a41f-045dce2ec9af") },
                    { new Guid("5780e65a-2413-4e93-9fef-2680a0e74f74"), null, null, "Немецкий язык", new Guid("165c2d31-2bec-4a6e-aa3a-c5b9ea4667af") },
                    { new Guid("5a7d6f43-3c24-438e-9115-0e0221c2b8b7"), null, null, "Испанский язык", new Guid("fda5cce1-d62a-40da-a41f-045dce2ec9af") },
                    { new Guid("687a83f6-311d-4c4a-82c9-376b3ce0c580"), null, null, "Основы безопасности жизнедеятельности", new Guid("fda5cce1-d62a-40da-a41f-045dce2ec9af") },
                    { new Guid("6ac497ea-664f-4c46-993e-3464aa439d7c"), null, null, "Французский язык", new Guid("fda5cce1-d62a-40da-a41f-045dce2ec9af") },
                    { new Guid("6da1fe70-1fe7-4236-9912-789b63bff6ee"), null, null, "Китайский язык", new Guid("c8f70d8d-f10d-4b0f-afe8-3ecc0b56db33") },
                    { new Guid("7022f9d7-cc8c-436b-8317-d34eee2d75f4"), null, null, "История России", new Guid("c8f70d8d-f10d-4b0f-afe8-3ecc0b56db33") },
                    { new Guid("74f652c1-e090-4100-adb7-1a66f345b336"), null, null, "Основы духовно-нравственной культуры народов России", new Guid("fda5cce1-d62a-40da-a41f-045dce2ec9af") },
                    { new Guid("77b26d88-a100-4757-aa79-f213f66c2df7"), null, null, "Обществознание", new Guid("c8f70d8d-f10d-4b0f-afe8-3ecc0b56db33") },
                    { new Guid("7ce52d06-c4f8-464e-b016-99b86f4f4742"), null, null, "Крымскотатарский язык", new Guid("6fa48385-d664-4a57-889a-4dd82a9ce6f4") },
                    { new Guid("7d027739-3626-4588-86f9-5999e3ad5604"), null, null, "Мокшанский язык", new Guid("6fa48385-d664-4a57-889a-4dd82a9ce6f4") },
                    { new Guid("7df4ef67-aa0c-4339-84af-149bffbe0a72"), null, null, "Бурятский язык", new Guid("6fa48385-d664-4a57-889a-4dd82a9ce6f4") },
                    { new Guid("8075827b-26dc-432a-8b48-c69546e60810"), null, null, "ИЗО", new Guid("165c2d31-2bec-4a6e-aa3a-c5b9ea4667af") },
                    { new Guid("88b7b483-8fdd-4464-9fe1-baac2e82f180"), null, null, "Кабардино-черкесский язык", new Guid("6fa48385-d664-4a57-889a-4dd82a9ce6f4") },
                    { new Guid("8b1784b9-6d31-4daf-a965-82324b4905c7"), null, null, "Физическая культура", new Guid("c8f70d8d-f10d-4b0f-afe8-3ecc0b56db33") },
                    { new Guid("8e619156-ca34-4a2b-beef-b332a6f0b832"), null, null, "Татарский язык", new Guid("6fa48385-d664-4a57-889a-4dd82a9ce6f4") },
                    { new Guid("8f167f9a-09da-4a5b-82b0-a2bcc849047f"), null, null, "Изобразительное искусство", new Guid("fda5cce1-d62a-40da-a41f-045dce2ec9af") },
                    { new Guid("8f5d054e-bff0-4f68-a44d-7e4b28f19807"), null, null, "Литература", new Guid("fda5cce1-d62a-40da-a41f-045dce2ec9af") },
                    { new Guid("92ac2c54-326d-471a-a854-c3aa201d8cf8"), null, null, "Биология", new Guid("c8f70d8d-f10d-4b0f-afe8-3ecc0b56db33") },
                    { new Guid("92ca0b32-a0d2-4a8b-b7ce-78177c1e132c"), null, null, "Химия", new Guid("fda5cce1-d62a-40da-a41f-045dce2ec9af") },
                    { new Guid("95fe2f1a-db70-4013-9bae-c235ddde7367"), null, null, "Музыка", new Guid("fda5cce1-d62a-40da-a41f-045dce2ec9af") },
                    { new Guid("973e3947-3a27-49a1-88a6-f1abfe21d2cb"), null, null, "Алгебра", new Guid("c8f70d8d-f10d-4b0f-afe8-3ecc0b56db33") },
                    { new Guid("a238ffa9-b4a8-4391-9616-5b920fcf355d"), null, null, "Карачаево-балкарский язык", new Guid("6fa48385-d664-4a57-889a-4dd82a9ce6f4") },
                    { new Guid("a389e8ee-6cd8-439f-a5d2-274b3ee9af8c"), null, null, "Чувашский язык", new Guid("6fa48385-d664-4a57-889a-4dd82a9ce6f4") },
                    { new Guid("a53e2d7d-79c6-46f3-ae1c-6063ecd8a79f"), null, null, "Английский язык", new Guid("c8f70d8d-f10d-4b0f-afe8-3ecc0b56db33") },
                    { new Guid("a65133ac-0027-4506-941c-64c171a70e2c"), null, null, "Дагестанский язык", new Guid("6fa48385-d664-4a57-889a-4dd82a9ce6f4") },
                    { new Guid("a7acf2b5-6331-48e7-9556-6cd4ed559bfa"), null, null, "Русский язык", new Guid("c8f70d8d-f10d-4b0f-afe8-3ecc0b56db33") },
                    { new Guid("a7bb2072-1b32-45ee-8853-08e67044fcc0"), null, null, "Чеченский язык", new Guid("6fa48385-d664-4a57-889a-4dd82a9ce6f4") },
                    { new Guid("ac58c912-3192-454f-b427-6334e1167d8a"), null, null, "Литература", new Guid("c8f70d8d-f10d-4b0f-afe8-3ecc0b56db33") },
                    { new Guid("aee7c118-9575-4d51-8428-1ede4080ad00"), null, null, "Химия", new Guid("c8f70d8d-f10d-4b0f-afe8-3ecc0b56db33") },
                    { new Guid("af3f3560-c3bd-4d25-8ba0-c0d2f53d30a5"), null, null, "Удмуртский язык", new Guid("6fa48385-d664-4a57-889a-4dd82a9ce6f4") },
                    { new Guid("afafb000-5a60-4243-a2ba-3306a5068d9d"), null, null, "История", new Guid("fda5cce1-d62a-40da-a41f-045dce2ec9af") },
                    { new Guid("b0f3ec6b-c54c-4ade-a63c-2ab4472e1487"), null, null, "Геометрия", new Guid("c8f70d8d-f10d-4b0f-afe8-3ecc0b56db33") },
                    { new Guid("b369b6db-2e96-427f-bf90-55ad3a85f687"), null, null, "Английский язык", new Guid("165c2d31-2bec-4a6e-aa3a-c5b9ea4667af") },
                    { new Guid("b81c2f0a-77f9-47ae-8c43-577b74d909c4"), null, null, "География", new Guid("c8f70d8d-f10d-4b0f-afe8-3ecc0b56db33") },
                    { new Guid("ba77e7ac-a3e6-4bfd-9a00-4acba329d70d"), null, null, "Испанский язык", new Guid("165c2d31-2bec-4a6e-aa3a-c5b9ea4667af") },
                    { new Guid("bb4e891a-a6b8-4f17-b958-61a79c9e70d4"), null, null, "Основы безопасности и жизнедеятельности", new Guid("c8f70d8d-f10d-4b0f-afe8-3ecc0b56db33") },
                    { new Guid("bcb87992-b879-450e-ba8e-7d91027a22d0"), null, null, "Тувинский язык", new Guid("6fa48385-d664-4a57-889a-4dd82a9ce6f4") },
                    { new Guid("be2008e4-12d6-4873-8abe-3638d8e56f44"), null, null, "Русский язык", new Guid("fda5cce1-d62a-40da-a41f-045dce2ec9af") },
                    { new Guid("c55d6bf9-5cad-4869-8a6c-55d11cd2b038"), null, null, "Коми язык", new Guid("6fa48385-d664-4a57-889a-4dd82a9ce6f4") },
                    { new Guid("c5cb4c49-5332-49e8-86ec-70912574653b"), null, null, "Обществознание", new Guid("165c2d31-2bec-4a6e-aa3a-c5b9ea4667af") },
                    { new Guid("c66e6944-d13c-4e4f-8adf-e4899a37bfba"), null, null, "Французский язык", new Guid("c8f70d8d-f10d-4b0f-afe8-3ecc0b56db33") },
                    { new Guid("c8959969-8a98-44d4-920e-3587a5003df8"), null, null, "Алгебра", new Guid("fda5cce1-d62a-40da-a41f-045dce2ec9af") },
                    { new Guid("cbf29783-4f26-41c7-8daa-ea0a877b5da4"), null, null, "Эрзянский язык", new Guid("6fa48385-d664-4a57-889a-4dd82a9ce6f4") },
                    { new Guid("ce955f13-ccdd-4ac5-9c95-8c82fc239ad8"), null, null, "Физика", new Guid("fda5cce1-d62a-40da-a41f-045dce2ec9af") },
                    { new Guid("cfe437fb-eb7c-49b8-bbb9-66282bdeb388"), null, null, "Геометрия", new Guid("fda5cce1-d62a-40da-a41f-045dce2ec9af") },
                    { new Guid("d1235962-df7b-4950-8af9-e6ab7b3366d6"), null, null, "Марийский язык", new Guid("6fa48385-d664-4a57-889a-4dd82a9ce6f4") },
                    { new Guid("d2862184-0930-4086-8053-8e4789dfecd4"), null, null, "Китайский язык", new Guid("fda5cce1-d62a-40da-a41f-045dce2ec9af") },
                    { new Guid("d940dbd6-36ab-427d-9eb8-a420bc647e23"), null, null, "Черчение", new Guid("c8f70d8d-f10d-4b0f-afe8-3ecc0b56db33") },
                    { new Guid("da5f60e2-755a-411a-ae09-b37c3895abcc"), null, null, "Абазинский язык", new Guid("6fa48385-d664-4a57-889a-4dd82a9ce6f4") },
                    { new Guid("dd9ececc-f132-40d8-9cdb-040317e8f4f8"), null, null, "Немецкий язык", new Guid("fda5cce1-d62a-40da-a41f-045dce2ec9af") },
                    { new Guid("e31e27b1-8f6c-43e7-bbeb-24804d4f9946"), null, null, "Информатика", new Guid("c8f70d8d-f10d-4b0f-afe8-3ecc0b56db33") },
                    { new Guid("eada3223-e4eb-439f-adcd-be559d52f03f"), null, null, "Испанский язык", new Guid("c8f70d8d-f10d-4b0f-afe8-3ecc0b56db33") },
                    { new Guid("f0d059e5-2ed9-4497-bde2-d16e87157a63"), null, null, "Физическая культура", new Guid("165c2d31-2bec-4a6e-aa3a-c5b9ea4667af") },
                    { new Guid("f369585a-a24f-4728-b386-5f727c981eff"), null, null, "Якутский язык", new Guid("6fa48385-d664-4a57-889a-4dd82a9ce6f4") },
                    { new Guid("f93e5416-a059-400f-a938-99923984ea65"), null, null, "Ногайский язык", new Guid("6fa48385-d664-4a57-889a-4dd82a9ce6f4") },
                    { new Guid("fba7a092-c5af-4006-ac18-f7c57e9f2b12"), null, null, "Адыгейский язык", new Guid("6fa48385-d664-4a57-889a-4dd82a9ce6f4") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("00fb379e-aa17-45b5-8294-eecee2f63735"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("04aa1506-33a2-4cda-a71f-aea2ee0e93c4"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("07f2dbc4-87ea-4aa1-bb4a-76e788b6a3b3"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("0d2607db-83f9-4802-8823-b0c29dab4e3b"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("1102b1bc-0309-4c6c-bf9b-affa5e29df65"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("164fcc6b-709f-4447-8b14-5882dcbcb142"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("16ae6f71-87d5-4a5c-a688-862e5b972ee9"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("1ed64895-d942-4ef1-a66f-ba487472374d"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("1f02d0e2-906f-4ac4-90ba-130abb83edfd"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("1f2b1cc2-f7ba-4958-8c64-dd1d17100aa9"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("2006004c-5bf4-4c3a-8569-1cf6616fc3bb"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("23221583-4e31-44f1-a345-863ba3515a09"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("235a8b7c-6d0a-4784-8f99-5f604d6b7aa9"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("253d3b7e-2bd1-40d0-a16a-32b139591a5c"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("292b7f75-1092-4827-9b49-5d87d4d7f4d8"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("2d0132a8-3960-4600-9fa2-d591a3366936"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("2ecfc2da-130e-434c-8cc7-208aafd97782"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("32af3f53-50f7-48b0-b41e-8c110490a136"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("344ee67f-b13d-4cae-97d5-1f56019afa88"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("34cde938-537d-4005-80ac-98a028c543b6"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("38beb114-7099-48b9-b574-b8a5c21ddbc5"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("3909e559-b3e9-4d2c-ae18-3c9731aca6a2"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("3a544249-e594-49f2-a373-fcd171a6f201"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("3ad52ae2-df87-499b-b2a0-7f4f8e2929e4"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("3c245e00-0a8a-4fad-8778-2f51ab8a7078"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("431c6ba3-bc64-4035-9869-f8308405dedb"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("45d2636b-b287-4ecb-b5dc-c630c161de3b"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("4684cfc8-ab0c-4652-b6a3-ef2b805ce55e"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("46aebcb7-b754-48ac-9ca5-689e282ed1a9"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("46ed4923-40a3-4ab9-9efd-f4ad111f4f6a"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("47116702-7301-4d25-ba45-6a16d13ae109"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("481141ff-1107-4cdf-a9d6-607e546c5f40"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("485b1dbf-63fd-4409-80ea-c68474ca4625"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("490a1d6e-2523-4b90-b23b-8b9020d4ad72"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("4c06cd4f-183b-41ef-b05d-40d2c6ed2a84"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("4eaa8de0-9468-4f42-961b-a9fe4d22ca79"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("5780e65a-2413-4e93-9fef-2680a0e74f74"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("5a7d6f43-3c24-438e-9115-0e0221c2b8b7"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("687a83f6-311d-4c4a-82c9-376b3ce0c580"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("6ac497ea-664f-4c46-993e-3464aa439d7c"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("6da1fe70-1fe7-4236-9912-789b63bff6ee"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("6dd3c2bd-c704-49a4-9560-15c8e2c2c47c"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("7022f9d7-cc8c-436b-8317-d34eee2d75f4"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("71c6e33d-bbf0-43de-89d1-4c3655887ebf"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("74f652c1-e090-4100-adb7-1a66f345b336"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("75d35df9-b838-4101-8c38-1e5c27e24fbf"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("77b26d88-a100-4757-aa79-f213f66c2df7"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("7ce52d06-c4f8-464e-b016-99b86f4f4742"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("7d027739-3626-4588-86f9-5999e3ad5604"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("7df4ef67-aa0c-4339-84af-149bffbe0a72"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("8075827b-26dc-432a-8b48-c69546e60810"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("84ad7bb2-effd-49d1-b0a1-2ad49680cf4a"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("855d7ca0-3e41-4ff0-816b-0e8aa83d9863"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("88b7b483-8fdd-4464-9fe1-baac2e82f180"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("8b1784b9-6d31-4daf-a965-82324b4905c7"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("8d32acd2-c31a-4666-8569-ffde5d353709"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("8e619156-ca34-4a2b-beef-b332a6f0b832"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("8ee5a3f5-9e7d-4234-9a1c-33da7f4e561b"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("8f167f9a-09da-4a5b-82b0-a2bcc849047f"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("8f5d054e-bff0-4f68-a44d-7e4b28f19807"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("92ac2c54-326d-471a-a854-c3aa201d8cf8"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("92ca0b32-a0d2-4a8b-b7ce-78177c1e132c"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("95fe2f1a-db70-4013-9bae-c235ddde7367"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("973e3947-3a27-49a1-88a6-f1abfe21d2cb"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("99548a47-fb5b-40c0-914f-0bbf259e3484"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("a044e007-8b86-453a-87d3-552e0f812da5"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("a238ffa9-b4a8-4391-9616-5b920fcf355d"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("a389e8ee-6cd8-439f-a5d2-274b3ee9af8c"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("a5136936-6e3f-4bfc-bc57-0dab989c734e"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("a53e2d7d-79c6-46f3-ae1c-6063ecd8a79f"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("a65133ac-0027-4506-941c-64c171a70e2c"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("a67d3ed3-cf97-4aa3-9a2b-a89ada98cdfb"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("a7acf2b5-6331-48e7-9556-6cd4ed559bfa"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("a7bb2072-1b32-45ee-8853-08e67044fcc0"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("aaf4967f-d0fb-4c07-b812-a2d90ebf7d6f"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("ac58c912-3192-454f-b427-6334e1167d8a"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("ad8387c8-75c0-45e3-8252-1fb5d6f5a38b"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("aee7c118-9575-4d51-8428-1ede4080ad00"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("af3f3560-c3bd-4d25-8ba0-c0d2f53d30a5"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("afafb000-5a60-4243-a2ba-3306a5068d9d"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("b0f3ec6b-c54c-4ade-a63c-2ab4472e1487"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("b369b6db-2e96-427f-bf90-55ad3a85f687"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("b81c2f0a-77f9-47ae-8c43-577b74d909c4"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("b856ae56-a5a3-4edf-a1a5-c8b47348ae95"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("ba77e7ac-a3e6-4bfd-9a00-4acba329d70d"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("bb4e891a-a6b8-4f17-b958-61a79c9e70d4"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("bcb87992-b879-450e-ba8e-7d91027a22d0"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("be2008e4-12d6-4873-8abe-3638d8e56f44"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("be4df5a7-8741-43ee-9157-d58ee14237b8"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("bf485cf7-f4f2-47ed-8aa9-387238efc878"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("c1952e80-3eaa-40a4-ba80-75e4e17571c1"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("c1fc8f18-655e-4ccc-8eae-fdf2ce4659e9"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("c55d6bf9-5cad-4869-8a6c-55d11cd2b038"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("c5cb4c49-5332-49e8-86ec-70912574653b"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("c66e6944-d13c-4e4f-8adf-e4899a37bfba"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("c8959969-8a98-44d4-920e-3587a5003df8"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("ca6835b0-4cf4-4cc7-84dd-49a0596950e8"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("cbf29783-4f26-41c7-8daa-ea0a877b5da4"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("ce955f13-ccdd-4ac5-9c95-8c82fc239ad8"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("cfe437fb-eb7c-49b8-bbb9-66282bdeb388"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("d1235962-df7b-4950-8af9-e6ab7b3366d6"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("d2862184-0930-4086-8053-8e4789dfecd4"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("d4e34dfe-3863-40dd-bf2b-de11e6985cfd"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("d605bec7-2b98-4860-9cf4-a688d2550fb0"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("d78a0d39-cdc0-4ec6-9077-d411379ecd96"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("d940dbd6-36ab-427d-9eb8-a420bc647e23"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("da5f60e2-755a-411a-ae09-b37c3895abcc"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("dd9ececc-f132-40d8-9cdb-040317e8f4f8"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("df5c6151-d5e7-4d66-91b4-53c3c4e9e9d4"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("dfc96a33-2d44-45ff-af8e-26c36780f41e"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("e22d7336-4ead-44cc-bf4d-90b73a0e924a"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("e31e27b1-8f6c-43e7-bbeb-24804d4f9946"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("e54ae0a3-2373-4899-83dc-76e91993c194"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("e671eaf1-f68e-476b-ba99-bc946f3a99b8"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("eada3223-e4eb-439f-adcd-be559d52f03f"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("f0d059e5-2ed9-4497-bde2-d16e87157a63"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("f369585a-a24f-4728-b386-5f727c981eff"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("f93e5416-a059-400f-a938-99923984ea65"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("fba7a092-c5af-4006-ac18-f7c57e9f2b12"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("fee5977c-07a8-4aa0-af63-63b7ee22bac4"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("01a91034-5e58-4b58-89c2-faf062eed3d7"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("165c2d31-2bec-4a6e-aa3a-c5b9ea4667af"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("6fa48385-d664-4a57-889a-4dd82a9ce6f4"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("a8f28f88-ebc5-4314-9c15-f2b9602a191e"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("c8f70d8d-f10d-4b0f-afe8-3ecc0b56db33"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("fda5cce1-d62a-40da-a41f-045dce2ec9af"));

            migrationBuilder.DeleteData(
                table: "TypeLessons",
                keyColumn: "Id",
                keyValue: new Guid("2b3132bf-cf29-4569-a9a3-19528b3f6196"));

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateBirthday",
                table: "Teacher",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "DateBirthday",
                table: "Students",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.InsertData(
                table: "TypeLessons",
                columns: new[] { "Id", "Category", "Description", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("0535648d-481f-40fe-a381-256af47acb97"), 8, null, "Искусство", null },
                    { new Guid("055ad00b-014d-446f-831f-9132bf6fabc6"), 2, null, "Технические науки", null },
                    { new Guid("0a282dac-7f68-4b64-b178-0b311d5c89a4"), 1, null, "ОГЭ", null },
                    { new Guid("429a8148-1daa-4e9f-9a56-f690c8a36dec"), 5, null, "Программирование", null },
                    { new Guid("4953f4ea-91f1-4168-9f53-e83bf909f572"), 7, null, "Музыка", null },
                    { new Guid("6578b2d1-579f-4c47-97d3-e0a32e945360"), 4, null, "Гуманитарные науки", null },
                    { new Guid("89513895-9af6-42f1-baed-347fad64a0d1"), 3, null, "Естественные науки", null },
                    { new Guid("ea0dc2c3-3b1a-45a0-b899-8ea58959596a"), 6, null, "Школьная программа", null },
                    { new Guid("f9527b95-fdf5-4319-9397-8d2aa964e39c"), 0, null, "ЕГЭ", null }
                });

            migrationBuilder.InsertData(
                table: "TypeLessons",
                columns: new[] { "Id", "Category", "Description", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("14050398-947e-45ef-b869-90e7f39b354c"), null, null, "Народные языки", new Guid("ea0dc2c3-3b1a-45a0-b899-8ea58959596a") },
                    { new Guid("142cbf52-4dba-45f8-8fab-65225db5f4d0"), null, null, "Математика (базовый уровень)", new Guid("f9527b95-fdf5-4319-9397-8d2aa964e39c") },
                    { new Guid("1df8b4f9-fb75-408b-96d0-cd6eaa78b0d7"), null, null, "Информатика", new Guid("0a282dac-7f68-4b64-b178-0b311d5c89a4") },
                    { new Guid("38dcd820-498a-473c-a96d-f7b59f7847b9"), null, null, "Математика", new Guid("0a282dac-7f68-4b64-b178-0b311d5c89a4") },
                    { new Guid("415faa0d-f144-4111-a20d-3f1a48f66ae4"), null, null, "География", new Guid("f9527b95-fdf5-4319-9397-8d2aa964e39c") },
                    { new Guid("41e925dd-a86c-4a5a-8a90-976aca725251"), null, null, "9-11 класс", new Guid("ea0dc2c3-3b1a-45a0-b899-8ea58959596a") },
                    { new Guid("44df0387-4298-4135-aeb9-9f4c8b0138c7"), null, null, "Биология", new Guid("f9527b95-fdf5-4319-9397-8d2aa964e39c") },
                    { new Guid("4c52f4a3-e327-418b-b639-3dd7c0c57d6d"), null, null, "География", new Guid("f9527b95-fdf5-4319-9397-8d2aa964e39c") },
                    { new Guid("4d1d9eab-47fa-4c9b-ba32-fa230fc82342"), null, null, "Обществознание", new Guid("0a282dac-7f68-4b64-b178-0b311d5c89a4") },
                    { new Guid("5996ad85-e770-4f2e-a50d-cacfe4d2ae77"), null, null, "Биология", new Guid("0a282dac-7f68-4b64-b178-0b311d5c89a4") },
                    { new Guid("5e2b2f23-071e-4423-9bf8-3a68b1f959f9"), null, null, "Информатика", new Guid("f9527b95-fdf5-4319-9397-8d2aa964e39c") },
                    { new Guid("68ac1ad8-002d-4186-bfc8-ebd5acf684e7"), null, null, "География", new Guid("0a282dac-7f68-4b64-b178-0b311d5c89a4") },
                    { new Guid("6b82965d-6973-4e3a-a379-8e76ab0b7a5d"), null, null, "Испанский язык", new Guid("0a282dac-7f68-4b64-b178-0b311d5c89a4") },
                    { new Guid("75c2c708-c285-4122-a427-0dac7be4e3bf"), null, null, "1-4 класс", new Guid("ea0dc2c3-3b1a-45a0-b899-8ea58959596a") },
                    { new Guid("767d7d86-d85f-476d-a503-591dadace88e"), null, null, "География", new Guid("0a282dac-7f68-4b64-b178-0b311d5c89a4") },
                    { new Guid("7f821cce-12b4-4ecc-8f2c-ed679a96aa83"), null, null, "Русский язык", new Guid("0a282dac-7f68-4b64-b178-0b311d5c89a4") },
                    { new Guid("80b25906-463d-4ff5-9315-28d0103320c3"), null, null, "Китайский язык", new Guid("f9527b95-fdf5-4319-9397-8d2aa964e39c") },
                    { new Guid("827231ba-2a43-4471-9a49-272c442c3a46"), null, null, "Английский язык", new Guid("0a282dac-7f68-4b64-b178-0b311d5c89a4") },
                    { new Guid("97e97f1c-2e66-42d3-b1cf-bf6700b33cf0"), null, null, "Русский язык", new Guid("f9527b95-fdf5-4319-9397-8d2aa964e39c") },
                    { new Guid("9a349dc6-cf9a-415c-9187-7e8056f9c4ee"), null, null, "Немецкий язык", new Guid("f9527b95-fdf5-4319-9397-8d2aa964e39c") },
                    { new Guid("9f902c9c-2a8b-4d11-a71d-c096c0aee3dd"), null, null, "Китайский язык", new Guid("0a282dac-7f68-4b64-b178-0b311d5c89a4") },
                    { new Guid("a0c4b74b-6557-436c-9f04-6f21284fdbcb"), null, null, "Математика (профильный уровень)", new Guid("f9527b95-fdf5-4319-9397-8d2aa964e39c") },
                    { new Guid("a95fa4bc-5438-463f-89b4-bccc5970f978"), null, null, "5-9 класс", new Guid("ea0dc2c3-3b1a-45a0-b899-8ea58959596a") },
                    { new Guid("ae96a6b2-0fca-4a04-b7a0-b2a17b43544b"), null, null, "Химия", new Guid("0a282dac-7f68-4b64-b178-0b311d5c89a4") },
                    { new Guid("b34bfec0-4d10-4d07-9cca-c90513dafd33"), null, null, "Английский язык", new Guid("f9527b95-fdf5-4319-9397-8d2aa964e39c") },
                    { new Guid("cb1d5053-22cb-4d11-b10e-8a2a9a2ccaae"), null, null, "История", new Guid("0a282dac-7f68-4b64-b178-0b311d5c89a4") },
                    { new Guid("d2b8db87-cb3f-4195-a9bb-99cf1d421d77"), null, null, "Обществознание", new Guid("f9527b95-fdf5-4319-9397-8d2aa964e39c") },
                    { new Guid("da8b5860-609d-4bab-b41e-6472425b58c0"), null, null, "Французский язык", new Guid("f9527b95-fdf5-4319-9397-8d2aa964e39c") },
                    { new Guid("e0bc384c-3f28-4f74-8019-3ba28d54b191"), null, null, "Испанский язык", new Guid("f9527b95-fdf5-4319-9397-8d2aa964e39c") },
                    { new Guid("e7b6612d-5452-4197-b2fc-e310c8eb1d51"), null, null, "Литература", new Guid("0a282dac-7f68-4b64-b178-0b311d5c89a4") },
                    { new Guid("e936fb76-e12a-4ddd-89e0-1186a6584ed2"), null, null, "Литература", new Guid("f9527b95-fdf5-4319-9397-8d2aa964e39c") },
                    { new Guid("ec612445-d7c1-4e62-a56d-8ead4427b393"), null, null, "Немецкий язык", new Guid("0a282dac-7f68-4b64-b178-0b311d5c89a4") },
                    { new Guid("ec71c836-faff-4e67-b515-95685d75980b"), null, null, "История", new Guid("f9527b95-fdf5-4319-9397-8d2aa964e39c") },
                    { new Guid("efeef0fe-3a1f-47e4-9e1c-bc3f86163a98"), null, null, "Химия", new Guid("f9527b95-fdf5-4319-9397-8d2aa964e39c") },
                    { new Guid("f73712ba-235f-4715-b12b-f904ad54b3be"), null, null, "Физика", new Guid("0a282dac-7f68-4b64-b178-0b311d5c89a4") },
                    { new Guid("fbd51f73-ded0-4e2a-b38a-1d34913d91df"), null, null, "Французский язык", new Guid("0a282dac-7f68-4b64-b178-0b311d5c89a4") },
                    { new Guid("fbf31ae2-9660-4de7-be60-06bb2385feea"), null, null, "Физика", new Guid("f9527b95-fdf5-4319-9397-8d2aa964e39c") }
                });

            migrationBuilder.InsertData(
                table: "TypeLessons",
                columns: new[] { "Id", "Category", "Description", "Name", "ParentId" },
                values: new object[,]
                {
                    { new Guid("0930de0c-aa1b-4ddd-8fc6-3141d9acf862"), null, null, "Черчение", new Guid("41e925dd-a86c-4a5a-8a90-976aca725251") },
                    { new Guid("0d501443-fc1c-4740-8381-6dcd951817d1"), null, null, "Испанский язык", new Guid("a95fa4bc-5438-463f-89b4-bccc5970f978") },
                    { new Guid("10cfe1f7-1a1e-4ae5-9c50-408bbdfecbbb"), null, null, "Кабардино-черкесский язык", new Guid("14050398-947e-45ef-b869-90e7f39b354c") },
                    { new Guid("114c4e97-fac3-49af-8944-591a27b7800d"), null, null, "Осетинский язык", new Guid("14050398-947e-45ef-b869-90e7f39b354c") },
                    { new Guid("1ce190c0-33df-4416-90ee-64e0b84f5021"), null, null, "Якутский язык", new Guid("14050398-947e-45ef-b869-90e7f39b354c") },
                    { new Guid("1df79adb-356c-4188-9561-f3c48e793f45"), null, null, "Обществознание", new Guid("a95fa4bc-5438-463f-89b4-bccc5970f978") },
                    { new Guid("24fa9a3a-9a81-43b4-b86b-9319924c328d"), null, null, "Геометрия", new Guid("a95fa4bc-5438-463f-89b4-bccc5970f978") },
                    { new Guid("25817e1a-0e6f-44bb-a11c-7e1e2a12343e"), null, null, "Ингушский язык", new Guid("14050398-947e-45ef-b869-90e7f39b354c") },
                    { new Guid("259039d5-8c60-4956-9f7b-fc45ed7bb359"), null, null, "Коми язык", new Guid("14050398-947e-45ef-b869-90e7f39b354c") },
                    { new Guid("282e1f6f-8a45-4b93-89d5-6d6ac33de3f7"), null, null, "Мокшанский язык", new Guid("14050398-947e-45ef-b869-90e7f39b354c") },
                    { new Guid("288b07e1-9286-4363-85db-4fcd924302ae"), null, null, "Обществознание", new Guid("75c2c708-c285-4122-a427-0dac7be4e3bf") },
                    { new Guid("29afff99-286c-4f22-b8a2-f0c36b2c3213"), null, null, "География", new Guid("41e925dd-a86c-4a5a-8a90-976aca725251") },
                    { new Guid("29de8143-1496-4959-b121-89e2e78659f1"), null, null, "Основы религиозных культур и светской этики", new Guid("a95fa4bc-5438-463f-89b4-bccc5970f978") },
                    { new Guid("2b7d7819-e50a-4d15-ae65-60a76d2eb2a2"), null, null, "Английский язык", new Guid("75c2c708-c285-4122-a427-0dac7be4e3bf") },
                    { new Guid("2ce7a3ff-c7e4-43f4-81d9-c3dd7902e262"), null, null, "Музыка", new Guid("75c2c708-c285-4122-a427-0dac7be4e3bf") },
                    { new Guid("30fbbe08-dc29-4e7e-9e07-a7e5680a9a5f"), null, null, "Всеобщая история", new Guid("41e925dd-a86c-4a5a-8a90-976aca725251") },
                    { new Guid("314fb244-951b-4a33-9862-c05a722bc220"), null, null, "Технология", new Guid("75c2c708-c285-4122-a427-0dac7be4e3bf") },
                    { new Guid("317240f9-a92e-49e2-b151-d048678939ec"), null, null, "История России", new Guid("41e925dd-a86c-4a5a-8a90-976aca725251") },
                    { new Guid("35873033-c65a-4307-bfd3-3aad386a8813"), null, null, "Химия", new Guid("41e925dd-a86c-4a5a-8a90-976aca725251") },
                    { new Guid("364728c7-7241-438f-832a-a8a9ccdde1b1"), null, null, "Хакасский язык", new Guid("14050398-947e-45ef-b869-90e7f39b354c") },
                    { new Guid("38e7e148-b27d-4746-b2ef-e62bad5b541b"), null, null, "Алтайский язык", new Guid("14050398-947e-45ef-b869-90e7f39b354c") },
                    { new Guid("3a6e4d78-b82f-4057-b50d-dcdc35aaa5ac"), null, null, "Биология", new Guid("a95fa4bc-5438-463f-89b4-bccc5970f978") },
                    { new Guid("3b0d52b4-4921-46d2-aa65-fb1cd36b8f92"), null, null, "Эрзянский язык", new Guid("14050398-947e-45ef-b869-90e7f39b354c") },
                    { new Guid("3ec952c0-bc6f-42a2-912d-4b7c3ee91e2a"), null, null, "Английский язык", new Guid("a95fa4bc-5438-463f-89b4-bccc5970f978") },
                    { new Guid("409c2801-79e4-4f01-aa8b-a574de3fc98c"), null, null, "Основы духовно-нравственной культуры народов России", new Guid("a95fa4bc-5438-463f-89b4-bccc5970f978") },
                    { new Guid("42d1121f-5621-4d22-adf2-fe363e675870"), null, null, "Окружающий мир", new Guid("75c2c708-c285-4122-a427-0dac7be4e3bf") },
                    { new Guid("44022d48-263c-4ecd-98eb-02068761df16"), null, null, "Информатика", new Guid("a95fa4bc-5438-463f-89b4-bccc5970f978") },
                    { new Guid("4a3e98ab-6fdf-4db0-831f-872b68a7836b"), null, null, "Китайский язык", new Guid("a95fa4bc-5438-463f-89b4-bccc5970f978") },
                    { new Guid("4b7249ea-71ed-4e15-aabc-48c63a731644"), null, null, "Крымскотатарский язык", new Guid("14050398-947e-45ef-b869-90e7f39b354c") },
                    { new Guid("4c03b5f3-5d6f-4e7e-a155-b6f41801fb50"), null, null, "Литературное чтение", new Guid("75c2c708-c285-4122-a427-0dac7be4e3bf") },
                    { new Guid("4f6dbab8-a7c6-46da-b3eb-cb83a64506b7"), null, null, "Французский язык", new Guid("41e925dd-a86c-4a5a-8a90-976aca725251") },
                    { new Guid("4f7c6d4e-2e9f-45ab-968f-79778c340f75"), null, null, "Ногайский язык", new Guid("14050398-947e-45ef-b869-90e7f39b354c") },
                    { new Guid("4fb68591-cd10-4d7a-b0cd-9ff6b453f564"), null, null, "Абазинский язык", new Guid("14050398-947e-45ef-b869-90e7f39b354c") },
                    { new Guid("53850ab0-5adf-475c-bd3c-b510cfe93642"), null, null, "История", new Guid("a95fa4bc-5438-463f-89b4-bccc5970f978") },
                    { new Guid("56563072-ebec-4d76-81c6-10aa20534119"), null, null, "ИЗО", new Guid("75c2c708-c285-4122-a427-0dac7be4e3bf") },
                    { new Guid("59c2eb7c-7626-4102-9844-043c5669aafd"), null, null, "Французский язык", new Guid("a95fa4bc-5438-463f-89b4-bccc5970f978") },
                    { new Guid("5d66f0c1-2754-42c8-8b52-3246c96518d0"), null, null, "Китайский язык", new Guid("75c2c708-c285-4122-a427-0dac7be4e3bf") },
                    { new Guid("677e9784-1f3e-47dc-abc7-e93eeb546e1d"), null, null, "Технология", new Guid("a95fa4bc-5438-463f-89b4-bccc5970f978") },
                    { new Guid("69935247-5ce7-48de-adc3-9111c89cf5fb"), null, null, "Чувашский язык", new Guid("14050398-947e-45ef-b869-90e7f39b354c") },
                    { new Guid("6a65c0cc-202c-421b-85f3-4557a8638593"), null, null, "География", new Guid("a95fa4bc-5438-463f-89b4-bccc5970f978") },
                    { new Guid("6cad4673-8c94-461e-8a7b-f8e9303fe7df"), null, null, "Литература", new Guid("41e925dd-a86c-4a5a-8a90-976aca725251") },
                    { new Guid("6fdb06b3-2b31-4a47-b0bf-11fb04737dad"), null, null, "Немецкий язык", new Guid("41e925dd-a86c-4a5a-8a90-976aca725251") },
                    { new Guid("71899516-dca4-4653-a359-44dd2dc1d771"), null, null, "Дагестанский язык", new Guid("14050398-947e-45ef-b869-90e7f39b354c") },
                    { new Guid("74de6b9a-51a5-410a-ba6f-3ce713b5a367"), null, null, "Русский язык", new Guid("41e925dd-a86c-4a5a-8a90-976aca725251") },
                    { new Guid("76f19ee7-4aef-4a14-950d-83df7ace10e8"), null, null, "Литература", new Guid("a95fa4bc-5438-463f-89b4-bccc5970f978") },
                    { new Guid("79cb6116-a9ae-43ac-898f-c737a4fdfbfa"), null, null, "Химия", new Guid("a95fa4bc-5438-463f-89b4-bccc5970f978") },
                    { new Guid("7ae2bdaf-4e70-4c54-9240-53c46e183f01"), null, null, "Удмуртский язык", new Guid("14050398-947e-45ef-b869-90e7f39b354c") },
                    { new Guid("7baef7c1-054c-435a-9447-9171c8d9adf9"), null, null, "Физическая культура", new Guid("75c2c708-c285-4122-a427-0dac7be4e3bf") },
                    { new Guid("7e8512ea-95d5-4abb-ad4e-8ac23bfd2bd8"), null, null, "Русский язык", new Guid("a95fa4bc-5438-463f-89b4-bccc5970f978") },
                    { new Guid("862ae15c-e91f-4b1a-ac29-7589f804674e"), null, null, "Математика", new Guid("75c2c708-c285-4122-a427-0dac7be4e3bf") },
                    { new Guid("8709c8e0-1ec1-44cf-917f-a95060477501"), null, null, "Чеченский язык", new Guid("14050398-947e-45ef-b869-90e7f39b354c") },
                    { new Guid("8711b9e3-19f0-4129-8c9e-d209066efd83"), null, null, "Испанский язык", new Guid("41e925dd-a86c-4a5a-8a90-976aca725251") },
                    { new Guid("8e1ad3a9-25ae-4649-b4ca-ab5643d306f4"), null, null, "Испанский язык", new Guid("75c2c708-c285-4122-a427-0dac7be4e3bf") },
                    { new Guid("a19e9168-e103-4542-bd4f-5a956b5c5231"), null, null, "Физическая культура", new Guid("41e925dd-a86c-4a5a-8a90-976aca725251") },
                    { new Guid("a30c0908-727e-47cb-937e-6d23c728c6a2"), null, null, "Карачаево-балкарский язык", new Guid("14050398-947e-45ef-b869-90e7f39b354c") },
                    { new Guid("a331929e-ff62-4f01-85a9-32fa52792ba7"), null, null, "Тувинский язык", new Guid("14050398-947e-45ef-b869-90e7f39b354c") },
                    { new Guid("b288ffd4-1c6a-4731-9954-99a1e655983f"), null, null, "Марийский язык", new Guid("14050398-947e-45ef-b869-90e7f39b354c") },
                    { new Guid("b5758162-2c91-44b4-b85c-0dcc03702f9e"), null, null, "Биология", new Guid("41e925dd-a86c-4a5a-8a90-976aca725251") },
                    { new Guid("b76a53a9-2e29-4b63-b4c5-ca02c9267da2"), null, null, "Изобразительное искусство", new Guid("a95fa4bc-5438-463f-89b4-bccc5970f978") },
                    { new Guid("befceccd-d521-497a-a3c9-3cb489982472"), null, null, "Основы безопасности жизнедеятельности", new Guid("a95fa4bc-5438-463f-89b4-bccc5970f978") },
                    { new Guid("befebe1c-7383-4659-9e79-4b11df9f8e99"), null, null, "Физическая культура", new Guid("a95fa4bc-5438-463f-89b4-bccc5970f978") },
                    { new Guid("c08eeaf2-93e0-41df-b74b-cd4aa9e49f87"), null, null, "Обществознание", new Guid("41e925dd-a86c-4a5a-8a90-976aca725251") },
                    { new Guid("ca4b47ab-706e-433a-aa02-4651352a2759"), null, null, "Немецкий язык", new Guid("75c2c708-c285-4122-a427-0dac7be4e3bf") },
                    { new Guid("ca82733f-3b73-49f0-8d43-6e5ce70b61d7"), null, null, "Башкирский язык", new Guid("14050398-947e-45ef-b869-90e7f39b354c") },
                    { new Guid("d059a026-2dbf-41e4-a472-f1521125f2ed"), null, null, "Китайский язык", new Guid("41e925dd-a86c-4a5a-8a90-976aca725251") },
                    { new Guid("d49d7557-8965-4bda-a636-8658c5e32390"), null, null, "Немецкий язык", new Guid("a95fa4bc-5438-463f-89b4-bccc5970f978") },
                    { new Guid("d5261858-74aa-490c-b724-b8d623aea4e7"), null, null, "Английский язык", new Guid("41e925dd-a86c-4a5a-8a90-976aca725251") },
                    { new Guid("d8f39c26-420b-4c98-949d-0f5abf2d7026"), null, null, "Татарский язык", new Guid("14050398-947e-45ef-b869-90e7f39b354c") },
                    { new Guid("dceb8cbd-d618-4f34-9ba7-091f464249d6"), null, null, "Физика", new Guid("a95fa4bc-5438-463f-89b4-bccc5970f978") },
                    { new Guid("dfa9e0d3-3d28-433e-898d-5f35e571ac0d"), null, null, "Французский язык", new Guid("75c2c708-c285-4122-a427-0dac7be4e3bf") },
                    { new Guid("e1c552d1-bf81-463e-b762-cc8afee9a3b7"), null, null, "Основы безопасности и жизнедеятельности", new Guid("41e925dd-a86c-4a5a-8a90-976aca725251") },
                    { new Guid("e56be609-d5c2-4581-add4-93015fb733b7"), null, null, "Физика", new Guid("41e925dd-a86c-4a5a-8a90-976aca725251") },
                    { new Guid("e5f001cd-f68a-4341-b000-f2c4079542d3"), null, null, "Алгебра", new Guid("41e925dd-a86c-4a5a-8a90-976aca725251") },
                    { new Guid("ed5f00ab-1612-485b-9fd9-7d9538c81a69"), null, null, "Адыгейский язык", new Guid("14050398-947e-45ef-b869-90e7f39b354c") },
                    { new Guid("f0a8882b-d601-466b-b01c-218d5795e998"), null, null, "Геометрия", new Guid("41e925dd-a86c-4a5a-8a90-976aca725251") },
                    { new Guid("f4d40764-d8d4-4c46-a8de-f8bf30a97ee1"), null, null, "Информатика", new Guid("41e925dd-a86c-4a5a-8a90-976aca725251") },
                    { new Guid("f6efba9d-77ef-4d81-817c-f4cad911fad2"), null, null, "Русский язык", new Guid("75c2c708-c285-4122-a427-0dac7be4e3bf") },
                    { new Guid("f87b8b38-b6bd-4675-b3c4-529d7e254ca6"), null, null, "Музыка", new Guid("a95fa4bc-5438-463f-89b4-bccc5970f978") },
                    { new Guid("f92002f0-c83a-4cc7-a052-c8b001f848bd"), null, null, "Бурятский язык", new Guid("14050398-947e-45ef-b869-90e7f39b354c") },
                    { new Guid("f9650001-705f-4c07-be6b-b6ac970141e0"), null, null, "Калмыцкий язык", new Guid("14050398-947e-45ef-b869-90e7f39b354c") },
                    { new Guid("fb441322-364a-4e6a-be55-754b1c2f5f8b"), null, null, "Алгебра", new Guid("a95fa4bc-5438-463f-89b4-bccc5970f978") }
                });
        }
    }
}
