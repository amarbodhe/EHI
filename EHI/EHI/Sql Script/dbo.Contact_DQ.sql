CREATE procedure [dbo].[Contact_DQ]  
(  @mode int,
	@id int
)  
as  
begin 
if @mode=1  --Save contact
begin

		Select
				Id,
				FirstName ,
				LastName ,
				Email ,
				PhoneNo ,
				Active
		from
				contact where id=@id

		
End
end