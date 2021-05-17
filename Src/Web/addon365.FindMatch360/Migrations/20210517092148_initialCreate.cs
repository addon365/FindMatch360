using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace addon365.FindMatch360.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CasteMasters",
                columns: table => new
                {
                    CasteMasterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CasteName = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CasteMasters", x => x.CasteMasterId);
                });

            migrationBuilder.CreateTable(
                name: "DoshamMasters",
                columns: table => new
                {
                    DoshamMasterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoshamName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoshamMasters", x => x.DoshamMasterId);
                });

            migrationBuilder.CreateTable(
                name: "EducationCategoryMasters",
                columns: table => new
                {
                    EducationCategoryMasterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationCategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationCategoryMasters", x => x.EducationCategoryMasterId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeedIndustryMasters",
                columns: table => new
                {
                    EmployeedIndustryMasterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeedIndustryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeedIndustryMasters", x => x.EmployeedIndustryMasterId);
                });

            migrationBuilder.CreateTable(
                name: "EmployeedInMasters",
                columns: table => new
                {
                    EmployeedInMasterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeedInName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeedInMasters", x => x.EmployeedInMasterId);
                });

            migrationBuilder.CreateTable(
                name: "FamilyStatusMasters",
                columns: table => new
                {
                    FamilyStatusMasterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamilStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyStatusMasters", x => x.FamilyStatusMasterId);
                });

            migrationBuilder.CreateTable(
                name: "FamilyTypeMasters",
                columns: table => new
                {
                    FamilyTypeMasterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamilyTypeName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyTypeMasters", x => x.FamilyTypeMasterId);
                });

            migrationBuilder.CreateTable(
                name: "FamilyValuesMasters",
                columns: table => new
                {
                    FamilyValuesMasterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamilyValuesName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FamilyValuesMasters", x => x.FamilyValuesMasterId);
                });

            migrationBuilder.CreateTable(
                name: "GothramMasters",
                columns: table => new
                {
                    GothramMasterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GothramName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GothramMasters", x => x.GothramMasterId);
                });

            migrationBuilder.CreateTable(
                name: "MaritalStatusMasters",
                columns: table => new
                {
                    MaritalStatusMasterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaritalStatusName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaritalStatusMasters", x => x.MaritalStatusMasterId);
                });

            migrationBuilder.CreateTable(
                name: "MotherTongueMasters",
                columns: table => new
                {
                    MotherTongueMasterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MotherTongueName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MotherTongueMasters", x => x.MotherTongueMasterId);
                });

            migrationBuilder.CreateTable(
                name: "OccupationMasters",
                columns: table => new
                {
                    OccupationMasterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccupationMasters", x => x.OccupationMasterId);
                });

            migrationBuilder.CreateTable(
                name: "ProfileForMasters",
                columns: table => new
                {
                    ProfileForId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileFor = table.Column<string>(nullable: true),
                    Gender = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileForMasters", x => x.ProfileForId);
                });

            migrationBuilder.CreateTable(
                name: "ReligionMasters",
                columns: table => new
                {
                    ReligionMasterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReligionName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReligionMasters", x => x.ReligionMasterId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubCasteMasters",
                columns: table => new
                {
                    SubCasterMasterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CasteMasterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCasteMasters", x => x.SubCasterMasterId);
                    table.ForeignKey(
                        name: "FK_SubCasteMasters_CasteMasters_CasteMasterId",
                        column: x => x.CasteMasterId,
                        principalTable: "CasteMasters",
                        principalColumn: "CasteMasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationMasters",
                columns: table => new
                {
                    EducationMasterId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EducationName = table.Column<string>(nullable: true),
                    EducationCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationMasters", x => x.EducationMasterId);
                    table.ForeignKey(
                        name: "FK_EducationMasters_EducationCategoryMasters_EducationCategoryId",
                        column: x => x.EducationCategoryId,
                        principalTable: "EducationCategoryMasters",
                        principalColumn: "EducationCategoryMasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MatrimonyProfiles",
                columns: table => new
                {
                    MatrimonyProfileId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Gender = table.Column<byte>(nullable: false),
                    DateandTimeOfBirth = table.Column<DateTime>(nullable: false),
                    MaritalStatusMasterId = table.Column<int>(nullable: true),
                    BodyType = table.Column<byte>(nullable: false),
                    Weight = table.Column<string>(nullable: true),
                    Height = table.Column<string>(nullable: true),
                    SkinColor = table.Column<string>(nullable: true),
                    AnyDisability = table.Column<bool>(nullable: false),
                    DisabilityDescription = table.Column<string>(nullable: true),
                    EatingHabit = table.Column<byte>(nullable: false),
                    Drinking = table.Column<byte>(nullable: false),
                    Smoking = table.Column<byte>(nullable: false),
                    EmployeedInMasterId = table.Column<int>(nullable: true),
                    WorkingAddress = table.Column<string>(nullable: true),
                    MonthlyRevenue = table.Column<string>(nullable: true),
                    ReligionMasterId = table.Column<int>(nullable: true),
                    MotherTongueMasterId = table.Column<int>(nullable: true),
                    CasteMasterId = table.Column<int>(nullable: true),
                    SubCasteMasterId = table.Column<int>(nullable: true),
                    GothramMasterId = table.Column<int>(nullable: true),
                    Star = table.Column<string>(nullable: true),
                    Rasi = table.Column<string>(nullable: true),
                    Lagnam = table.Column<string>(nullable: true),
                    TimeofBirth = table.Column<string>(nullable: true),
                    PlaceOfBirth = table.Column<string>(nullable: true),
                    FamilyStatusMasterId = table.Column<int>(nullable: true),
                    FamilyTypeMasterId = table.Column<int>(nullable: true),
                    FamilyValuesMasterId = table.Column<int>(nullable: true),
                    FatherName = table.Column<string>(nullable: true),
                    FatherQualification = table.Column<string>(nullable: true),
                    FatherJob = table.Column<string>(nullable: true),
                    MotherName = table.Column<string>(nullable: true),
                    MotherQualification = table.Column<string>(nullable: true),
                    MotherJob = table.Column<string>(nullable: true),
                    NativeDistrict = table.Column<string>(nullable: true),
                    ContactPerson = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PhoneNo = table.Column<string>(nullable: true),
                    MobileNo = table.Column<string>(nullable: true),
                    EmailId = table.Column<string>(nullable: true),
                    BirthNumberinFamily = table.Column<short>(nullable: false),
                    Brothers = table.Column<short>(nullable: false),
                    MarriedBrothers = table.Column<short>(nullable: false),
                    Sisters = table.Column<short>(nullable: false),
                    MarriedSisters = table.Column<short>(nullable: false),
                    FromAge = table.Column<byte>(nullable: false),
                    UptoAge = table.Column<byte>(nullable: false),
                    PreferenceStar = table.Column<string>(nullable: true),
                    PreferenceRasi = table.Column<string>(nullable: true),
                    PreferenceChavvaiDosham = table.Column<string>(nullable: true),
                    PreferenceQualification = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatrimonyProfiles", x => x.MatrimonyProfileId);
                    table.ForeignKey(
                        name: "FK_MatrimonyProfiles_CasteMasters_CasteMasterId",
                        column: x => x.CasteMasterId,
                        principalTable: "CasteMasters",
                        principalColumn: "CasteMasterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatrimonyProfiles_EmployeedInMasters_EmployeedInMasterId",
                        column: x => x.EmployeedInMasterId,
                        principalTable: "EmployeedInMasters",
                        principalColumn: "EmployeedInMasterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatrimonyProfiles_FamilyStatusMasters_FamilyStatusMasterId",
                        column: x => x.FamilyStatusMasterId,
                        principalTable: "FamilyStatusMasters",
                        principalColumn: "FamilyStatusMasterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatrimonyProfiles_FamilyTypeMasters_FamilyTypeMasterId",
                        column: x => x.FamilyTypeMasterId,
                        principalTable: "FamilyTypeMasters",
                        principalColumn: "FamilyTypeMasterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatrimonyProfiles_FamilyValuesMasters_FamilyValuesMasterId",
                        column: x => x.FamilyValuesMasterId,
                        principalTable: "FamilyValuesMasters",
                        principalColumn: "FamilyValuesMasterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatrimonyProfiles_GothramMasters_GothramMasterId",
                        column: x => x.GothramMasterId,
                        principalTable: "GothramMasters",
                        principalColumn: "GothramMasterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatrimonyProfiles_MaritalStatusMasters_MaritalStatusMasterId",
                        column: x => x.MaritalStatusMasterId,
                        principalTable: "MaritalStatusMasters",
                        principalColumn: "MaritalStatusMasterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatrimonyProfiles_MotherTongueMasters_MotherTongueMasterId",
                        column: x => x.MotherTongueMasterId,
                        principalTable: "MotherTongueMasters",
                        principalColumn: "MotherTongueMasterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatrimonyProfiles_ReligionMasters_ReligionMasterId",
                        column: x => x.ReligionMasterId,
                        principalTable: "ReligionMasters",
                        principalColumn: "ReligionMasterId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MatrimonyProfiles_SubCasteMasters_SubCasteMasterId",
                        column: x => x.SubCasteMasterId,
                        principalTable: "SubCasteMasters",
                        principalColumn: "SubCasterMasterId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ProfileForId = table.Column<int>(nullable: true),
                    ProfileMatrimonyProfileId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_ProfileForMasters_ProfileForId",
                        column: x => x.ProfileForId,
                        principalTable: "ProfileForMasters",
                        principalColumn: "ProfileForId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_MatrimonyProfiles_ProfileMatrimonyProfileId",
                        column: x => x.ProfileMatrimonyProfileId,
                        principalTable: "MatrimonyProfiles",
                        principalColumn: "MatrimonyProfileId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProfileDoshams",
                columns: table => new
                {
                    ProfileDoshamsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<Guid>(nullable: false),
                    DoshamId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileDoshams", x => x.ProfileDoshamsId);
                    table.ForeignKey(
                        name: "FK_ProfileDoshams_DoshamMasters_DoshamId",
                        column: x => x.DoshamId,
                        principalTable: "DoshamMasters",
                        principalColumn: "DoshamMasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileDoshams_MatrimonyProfiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "MatrimonyProfiles",
                        principalColumn: "MatrimonyProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfileEducations",
                columns: table => new
                {
                    ProfileEducationsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<Guid>(nullable: false),
                    EducationMasterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfileEducations", x => x.ProfileEducationsId);
                    table.ForeignKey(
                        name: "FK_ProfileEducations_EducationMasters_EducationMasterId",
                        column: x => x.EducationMasterId,
                        principalTable: "EducationMasters",
                        principalColumn: "EducationMasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfileEducations_MatrimonyProfiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "MatrimonyProfiles",
                        principalColumn: "MatrimonyProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfilePhotos",
                columns: table => new
                {
                    ProfilePhotosId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<Guid>(nullable: false),
                    Photo = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilePhotos", x => x.ProfilePhotosId);
                    table.ForeignKey(
                        name: "FK_ProfilePhotos_MatrimonyProfiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "MatrimonyProfiles",
                        principalColumn: "MatrimonyProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfilePreferenceCastes",
                columns: table => new
                {
                    ProfilePreferenceCasteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<Guid>(nullable: false),
                    CasteMasterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilePreferenceCastes", x => x.ProfilePreferenceCasteId);
                    table.ForeignKey(
                        name: "FK_ProfilePreferenceCastes_CasteMasters_CasteMasterId",
                        column: x => x.CasteMasterId,
                        principalTable: "CasteMasters",
                        principalColumn: "CasteMasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfilePreferenceCastes_MatrimonyProfiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "MatrimonyProfiles",
                        principalColumn: "MatrimonyProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfilePreferenceEducations",
                columns: table => new
                {
                    ProfileEducationsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<Guid>(nullable: false),
                    EducationMasterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilePreferenceEducations", x => x.ProfileEducationsId);
                    table.ForeignKey(
                        name: "FK_ProfilePreferenceEducations_EducationMasters_EducationMasterId",
                        column: x => x.EducationMasterId,
                        principalTable: "EducationMasters",
                        principalColumn: "EducationMasterId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfilePreferenceEducations_MatrimonyProfiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "MatrimonyProfiles",
                        principalColumn: "MatrimonyProfileId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfilePreferenceReligions",
                columns: table => new
                {
                    ProfilePreferenceReligionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<Guid>(nullable: false),
                    ReligionMasterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilePreferenceReligions", x => x.ProfilePreferenceReligionId);
                    table.ForeignKey(
                        name: "FK_ProfilePreferenceReligions_MatrimonyProfiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "MatrimonyProfiles",
                        principalColumn: "MatrimonyProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfilePreferenceReligions_ReligionMasters_ReligionMasterId",
                        column: x => x.ReligionMasterId,
                        principalTable: "ReligionMasters",
                        principalColumn: "ReligionMasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProfilePreferenceSubCastes",
                columns: table => new
                {
                    ProfilePreferenceSubCasteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileId = table.Column<Guid>(nullable: false),
                    SubCasteMasterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfilePreferenceSubCastes", x => x.ProfilePreferenceSubCasteId);
                    table.ForeignKey(
                        name: "FK_ProfilePreferenceSubCastes_MatrimonyProfiles_ProfileId",
                        column: x => x.ProfileId,
                        principalTable: "MatrimonyProfiles",
                        principalColumn: "MatrimonyProfileId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProfilePreferenceSubCastes_SubCasteMasters_SubCasteMasterId",
                        column: x => x.SubCasteMasterId,
                        principalTable: "SubCasteMasters",
                        principalColumn: "SubCasterMasterId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProfileForId",
                table: "AspNetUsers",
                column: "ProfileForId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ProfileMatrimonyProfileId",
                table: "AspNetUsers",
                column: "ProfileMatrimonyProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationMasters_EducationCategoryId",
                table: "EducationMasters",
                column: "EducationCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MatrimonyProfiles_CasteMasterId",
                table: "MatrimonyProfiles",
                column: "CasteMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_MatrimonyProfiles_EmployeedInMasterId",
                table: "MatrimonyProfiles",
                column: "EmployeedInMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_MatrimonyProfiles_FamilyStatusMasterId",
                table: "MatrimonyProfiles",
                column: "FamilyStatusMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_MatrimonyProfiles_FamilyTypeMasterId",
                table: "MatrimonyProfiles",
                column: "FamilyTypeMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_MatrimonyProfiles_FamilyValuesMasterId",
                table: "MatrimonyProfiles",
                column: "FamilyValuesMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_MatrimonyProfiles_GothramMasterId",
                table: "MatrimonyProfiles",
                column: "GothramMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_MatrimonyProfiles_MaritalStatusMasterId",
                table: "MatrimonyProfiles",
                column: "MaritalStatusMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_MatrimonyProfiles_MotherTongueMasterId",
                table: "MatrimonyProfiles",
                column: "MotherTongueMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_MatrimonyProfiles_ReligionMasterId",
                table: "MatrimonyProfiles",
                column: "ReligionMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_MatrimonyProfiles_SubCasteMasterId",
                table: "MatrimonyProfiles",
                column: "SubCasteMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileDoshams_DoshamId",
                table: "ProfileDoshams",
                column: "DoshamId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileDoshams_ProfileId",
                table: "ProfileDoshams",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileEducations_EducationMasterId",
                table: "ProfileEducations",
                column: "EducationMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfileEducations_ProfileId",
                table: "ProfileEducations",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePhotos_ProfileId",
                table: "ProfilePhotos",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePreferenceCastes_CasteMasterId",
                table: "ProfilePreferenceCastes",
                column: "CasteMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePreferenceCastes_ProfileId",
                table: "ProfilePreferenceCastes",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePreferenceEducations_EducationMasterId",
                table: "ProfilePreferenceEducations",
                column: "EducationMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePreferenceEducations_ProfileId",
                table: "ProfilePreferenceEducations",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePreferenceReligions_ProfileId",
                table: "ProfilePreferenceReligions",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePreferenceReligions_ReligionMasterId",
                table: "ProfilePreferenceReligions",
                column: "ReligionMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePreferenceSubCastes_ProfileId",
                table: "ProfilePreferenceSubCastes",
                column: "ProfileId");

            migrationBuilder.CreateIndex(
                name: "IX_ProfilePreferenceSubCastes_SubCasteMasterId",
                table: "ProfilePreferenceSubCastes",
                column: "SubCasteMasterId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCasteMasters_CasteMasterId",
                table: "SubCasteMasters",
                column: "CasteMasterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "EmployeedIndustryMasters");

            migrationBuilder.DropTable(
                name: "OccupationMasters");

            migrationBuilder.DropTable(
                name: "ProfileDoshams");

            migrationBuilder.DropTable(
                name: "ProfileEducations");

            migrationBuilder.DropTable(
                name: "ProfilePhotos");

            migrationBuilder.DropTable(
                name: "ProfilePreferenceCastes");

            migrationBuilder.DropTable(
                name: "ProfilePreferenceEducations");

            migrationBuilder.DropTable(
                name: "ProfilePreferenceReligions");

            migrationBuilder.DropTable(
                name: "ProfilePreferenceSubCastes");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "DoshamMasters");

            migrationBuilder.DropTable(
                name: "EducationMasters");

            migrationBuilder.DropTable(
                name: "ProfileForMasters");

            migrationBuilder.DropTable(
                name: "MatrimonyProfiles");

            migrationBuilder.DropTable(
                name: "EducationCategoryMasters");

            migrationBuilder.DropTable(
                name: "EmployeedInMasters");

            migrationBuilder.DropTable(
                name: "FamilyStatusMasters");

            migrationBuilder.DropTable(
                name: "FamilyTypeMasters");

            migrationBuilder.DropTable(
                name: "FamilyValuesMasters");

            migrationBuilder.DropTable(
                name: "GothramMasters");

            migrationBuilder.DropTable(
                name: "MaritalStatusMasters");

            migrationBuilder.DropTable(
                name: "MotherTongueMasters");

            migrationBuilder.DropTable(
                name: "ReligionMasters");

            migrationBuilder.DropTable(
                name: "SubCasteMasters");

            migrationBuilder.DropTable(
                name: "CasteMasters");
        }
    }
}
