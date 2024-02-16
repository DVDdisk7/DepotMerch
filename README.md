
# DepotMerch

DepotMerch is een simpele webapp gebaseerd op Blazor en C# voor de interne merchandise shop van Depot Software. In de week van 12 t/m 16 februari heb ik voor mijn beroepsstage meegelopen bij Depot Software, en heb ik deze applicatie ontwikkeld. 

Werk je hier aan verder? Veel succes met alles ontcijferen :)

Deze repository bevat een export van de SQL database.




## Welke functionaliteiten bevat de webapp?

- Een gebruiker kan producten bekijken via de website
- Er kan een account aangemaakt worden via de ingebouwde Identity Manager
- Een beheerder kan producten toevoegen, aanpassen of verwijderen
- Een API die communiceert met de database om de producten te beheren.

## Todo
- Een functie maken zodat de gebruiker producten in een winkelwagen kan doen en deze kan weergeven
- Een accountfunctionaliteit voor de gebruiker (Is nu alleen de beheerder)
- Een functie waarbij de beheerder geen Image Url hoeft toe te voegen, maar een image kan uploaden
- Een functie waarmee de geldigheid van de image wordt gecheckt (ImageService)
- Een functie maken waarmee de gebruiker daadwerkelijk de producten in zijn winkelwagen kan bestellen. Deze bestellingen komen dan in de database terecht en kunnen worden bekeken door de beheerder. Er zitten al voorbereidende dingen in, zoals 'orders' table in de database.
- Een veilige API. Producten kunnen niet zo maar door iedereen worden bewerkt, toegevoegd of verwijderd worden. Ook moet de API garbage proof zijn en input kunnen filteren en afhandelen.




## API Reference
#### Swagger Documentation: https://URL/swagger/index.html

#### Get all products

```http
  GET /api/Product
```

#### Get product
```http
  GET /api/Product/${id}
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required**. Id of product to fetch |

#### Create new product

```http
  POST /api/Product/
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required** |
| `name`      | `string` | **Required** |
| `description`      | `string` | **Required** |
| `price`      | `decimal(18,2)` | **Required** |
| `imageUrl`      | `string` | optional |

#### Edit product

```http
  PUT /api/Product/
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required** |
| `name`      | `string` | optional |
| `description`      | `string` | optional |
| `price`      | `decimal(18,2)` | optional |
| `imageUrl`      | `string` | optional |

#### Delete product

```http
  DELETE /api/Product/
```

| Parameter | Type     | Description                       |
| :-------- | :------- | :-------------------------------- |
| `id`      | `string` | **Required** |


