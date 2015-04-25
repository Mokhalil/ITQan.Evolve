CREATE TABLE [dbo].[Benefits]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY(1, 1001), 
    [Membership_Category_Id] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_Benefits_ToMembershipCategoryTable] FOREIGN KEY (Membership_Category_Id) REFERENCES Membership_Category(Id)
)
