```zsh
SA_PASSWORD=[YOUR PASSWORD]

dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=localhost; Database=Books; User Id=sa; Password=$SA_PASSWORD; TrustServerCertificate=True"
```
