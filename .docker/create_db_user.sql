CREATE LOGIN PotionShoppe WITH PASSWORD = 'PotionPassword1!';
CREATE USER PotionShoppe FOR LOGIN PotionShoppe;
ALTER SERVER ROLE [dbcreator]
ADD MEMBER [PotionShoppe];
