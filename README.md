## Tecnology

* .NET
* FluentMigrations
* SQLite
* Dapper

## Authentication

There is currently no authentication implemented. Ignore the TokenController for now, we are not using that generated token in our api.


## Architecture

We are using an architecture called "Sweet Clean Architecture" where the layers live in a single project.

- Application (Controllers (presentation), Services )
  - Infrastructure (External Services)
- Entities (Entities)

**Note:**

The interface live in the folders related to their implementation, if we are to refactor this into a proper clean architecture then we will move the interface into their appropriate place.