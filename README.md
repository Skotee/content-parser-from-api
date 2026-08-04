# Generic API Parser

Generyczny parser danych przesyłanych przez API (.NET / C#) 

## Wymagania

Zainstalowane środowisko .NET 10 na komputerze
- [.NET 10 SDK](https://dotnet.microsoft.com/download)

## Uruchomienie lokalne

```bash
cd ContentApiParser.Api
dotnet run
```

Aplikacja wystartuje pod adresem `http://localhost:5009`.

## Przykładowe żądanie

```bash
curl -X POST http://localhost:5009/api/v1/parse-content \
  -H "Content-Type: application/json" \
  -d '{"type":"CSV","content":"bmFtZSxhZ2UKSmFuLDI1"}'
```

Gotowe przykłady żądań (CSV i INTERNAL_JSON) znajdują się też w pliku [`ContentApiParser.Api/ContentApiParser.Api.http`](ContentApiParser.Api/ContentApiParser.Api.http) — można je odpalić bezpośrednio z edytora (np. rozszerzenie REST Client w VSCode).

## Testy

```bash
dotnet test
```
