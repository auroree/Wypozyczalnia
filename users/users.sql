 Creates the login LoginAccessor with password 'specialpassword'.
CREATE LOGIN LoginAccessor 
    WITH PASSWORD = 'specialpassword';
GO

 Creates a database user for the login created above.
CREATE USER LoginAccessor FOR LOGIN LoginAccessor;
GO

USE Wypozyczalnia;

GRANT SELECT ON U¿ytkownicy
	TO LoginAccessor;
GO

GRANT SELECT ON OBJECT::LoginAs
    TO LoginAccessor;
GO

GRANT SELECT ON Funkcja
	TO LoginAccessor;
GO

CREATE LOGIN Sprzedawca 
    WITH PASSWORD = 'Sprzedawca1';
GO

CREATE USER Sprzedawca FOR LOGIN Sprzedawca;
GO

GRANT SELECT ON Klient
	TO Sprzedawca;
GO

GRANT SELECT ON Statek
	TO Sprzedawca;
GO

GRANT SELECT ON Rezerwacja
	TO Sprzedawca;
GO

GRANT SELECT ON Typ_statku
	TO Sprzedawca;
GO

--------KADROWY-------------

CREATE LOGIN Kadrowy 
    WITH PASSWORD = 'Kadrowy1';
GO

CREATE USER Kadrowy FOR LOGIN Kadrowy;
GO

GRANT SELECT,INSERT,DELETE,UPDATE ON pilotuje
	TO Kadrowy;
GO

GRANT SELECT,INSERT,UPDATE ON Funkcja
	TO Kadrowy;
GO

GRANT SELECT,INSERT,UPDATE ON Pracownik
	TO Kadrowy;
GO

------SERWISANT---------

CREATE LOGIN Serwisant 
    WITH PASSWORD = 'Serwisant1';
GO

CREATE USER Serwisant FOR LOGIN Serwisant;
GO

GRANT SELECT,INSERT,UPDATE ON Czêœæ
	TO Serwisant;
GO

GRANT SELECT,INSERT,DELETE,UPDATE ON jest_serwisowany
	TO Serwisant;
GO

GRANT SELECT,INSERT,UPDATE ON Statek
	TO Serwisant;
GO

GRANT SELECT,INSERT,DELETE,UPDATE ON Status_czêœci
	TO Serwisant;
GO

GRANT SELECT,INSERT,UPDATE ON Typ_statku
	TO Serwisant;
GO


------MAGAZYNIER---------

CREATE LOGIN Magazynier 
    WITH PASSWORD = 'Magazynier1';
GO

CREATE USER Magazynier FOR LOGIN Magazynier;
GO

GRANT SELECT,INSERT,UPDATE ON Czêœæ
	TO Magazynier;
GO

--GRANT SELECT,INSERT,DELETE,UPDATE ON jest_serwisowany
--	TO Magazynier;
--GO

--GRANT SELECT,INSERT,UPDATE ON Statek
--	TO Magazynier;
--GO

--GRANT SELECT,INSERT,DELETE,UPDATE ON Status_czêœci
--	TO Magazynier;
--GO

GRANT SELECT,INSERT,UPDATE ON Zamówienie
	TO Magazynier;
GO

------ADMIN-----------

CREATE LOGIN Admin 
    WITH PASSWORD = 'Admin1';
GO

CREATE USER Admin FOR LOGIN Admin;
GO

GRANT SELECT,INSERT,DELETE,UPDATE ON pilotuje
	TO Admin;
GO

GRANT SELECT,INSERT,DELETE,UPDATE ON Funkcja
	TO Admin;
GO

GRANT SELECT,INSERT,DELETE,UPDATE ON Pracownik
	TO Admin;
GO

GRANT SELECT,INSERT,DELETE,UPDATE ON Czêœæ
	TO Admin;
GO

GRANT SELECT,INSERT,DELETE,UPDATE ON jest_serwisowany
	TO Admin;
GO

GRANT SELECT,INSERT,DELETE,UPDATE ON Statek
	TO Admin;
GO

GRANT SELECT,INSERT,DELETE,UPDATE ON Status_czêœci
	TO Admin;
GO

GRANT SELECT,INSERT,DELETE,UPDATE ON Typ_statku
	TO Admin;
GO

GRANT SELECT,INSERT,DELETE,UPDATE ON Klient
	TO Admin;
GO

GRANT SELECT,INSERT,DELETE,UPDATE ON Rezerwacja
	TO Admin;
GO

GRANT SELECT,INSERT,DELETE,UPDATE ON Zamówienie
	TO Admin;
GO

GRANT SELECT,INSERT,DELETE,UPDATE ON Uprawnienia
	TO Admin;
GO

GRANT SELECT,INSERT,DELETE,UPDATE ON U¿ytkownik
	TO Admin;
GO