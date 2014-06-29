
CREATE FUNCTION LoginAs 
( @nazwa varchar(64), @haslo varchar(64) )
RETURNS table
    AS
    RETURN (
	select Funkcja, Up.Has³o from Uprawnienia Up, U¿ytkownik Uz 
	where Uprawnienia_Uprawnienia_ID = Uprawnienia_ID
	and Uz.Nazwa like @nazwa and Uz.Has³o like @haslo
	)
    