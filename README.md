# PotionShop

Mock Potion Shop Website

### Useful Links

-   [Jira Board](https://potionshoppe.atlassian.net/jira/software/projects/PS/boards/2)
-   [GitHub](https://github.com/devMichaelREdwards/PotionShoppe)

TODO: Write more on the Readme

Have installed ->
WSL2
Docker

Dev environment info ->
Database: localhost:1433 (sqlserver if inside container)
API: localhost:7211 (api if inside container)

Dev environment setup ->
dotnet dev-certs https --trust
docker compose up -d --build
Run SQL user script
Log in as new SQL user
Run SQL install script
