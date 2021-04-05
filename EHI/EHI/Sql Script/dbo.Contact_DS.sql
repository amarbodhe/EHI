
CREATE procedure [dbo].[Contact_DS]  
(  @mode int
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
				Active,
				Created_Date
		from
				contact

		
End
end