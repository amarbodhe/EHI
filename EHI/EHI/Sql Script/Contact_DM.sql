
CREATE procedure [dbo].[Contact_DM]  
(  @mode int,
@id int null,
   @FirstName nvarchar(50)null,
   @LastName nvarchar(50) null,
   @Email nvarchar(100)null,
   @PhoneNo nvarchar(20)null,
   @Active bit NULL ,
   @error int null output
)  
as  
begin 
if @mode=4  --Save contact
begin
		   Insert into Contact
		(
		FirstName ,
		LastName ,
		Email ,
		PhoneNo ,
		Active,
		Created_Date
		)
			values(

		@FirstName ,
		@LastName ,
		@Email ,
		@PhoneNo ,
		@Active,
		getdate()

		)  
		 if @@ROWCOUNT >0
				set @error =200
		 else
				set @error =400
End
else if @mode=16  --Update contact
begin
			   update Contact set
			FirstName =@FirstName,
			LastName=@LastName ,
			Email= @Email,
			PhoneNo=@PhoneNo ,
			Active =@Active,
			 Modified_Date= getdate() where id =@id

			 if @@ROWCOUNT >0
					set @error =200
			 else
					set @error =400

End
else if @mode=8  --delete contact
begin
		  delete from contact where id =@id
		 if @@ROWCOUNT >0
				set @error =200
		 else
				set @error =400

End
End