Feature: Login
	Login Olma Senaryoları

Scenario: Basarili Login Olma
	* Giris butonuna tiklanir
	* E-posta alanina 'testuser123124@gmail.com' yazilir
	* Şifre alanina 'Mustafa12345' yazilir
	* Giris Yap butonuna tiklanir
	* Basarili giris yapildigi gorulur

Scenario: Basarisiz Login Olma
	* Giris butonuna tiklanir
	* E-posta alanina 'testuser123124@gmail.com' yazilir
	* Şifre alanina 'Mustafa1' yazilir
	* Giris Yap butonuna tiklanir
	* Basarili giris yapilamadigi gorulur

Scenario: Basarisiz Login Olma Hata Mesaji
	* Giris butonuna tiklanir
	* E-posta alanina 'testuser123124@gmail.com' yazilir
	* Şifre alanina '' yazilir
	* Giris Yap butonuna tiklanir
	* Bu alanin doldurulmasi zorunludur mesaji gorulur

Scenario: Uzun Karakter Sifre Basarisiz Login Olma
	* Giris butonuna tiklanir
	* E-posta alanina 'testuser123124@gmail.com' yazilir
	* Şifre alanina 'Mustafa12345sdfsdf132432432sdfsdfsdfsdfsd' yazilir
	* Giris Yap butonuna tiklanir
	* Basarili giris yapilamadigi gorulur

Scenario: E-posta ve Sifresiz Basarisiz Login Olma Hata Mesaji
	* Giris butonuna tiklanir
	* E-posta alanina '' yazilir
	* Şifre alanina '' yazilir
	* Giris Yap butonuna tiklanir
	* Bu alanin doldurulmasi zorunludur mesaji gorulur