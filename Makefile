# Makefile

# db-reset will tear down the database and recreate it from scratch.
db-reset: db-teardown db-bootstrap

# db-bootstrap creates the database, runs migrations and seeds data.
db-bootstrap: db-create db-start

# db-teardown will stop and destroy the database.
db-teardown: db-stop db-destroy

# db-create creates a podman container for the database.
db-create:
	@ echo "--> Creating database container"
	podman create \
		-p 5432:5432 \
		--name proiect-web-db \
		-e POSTGRES_DB=proiect-web \
		-e POSTGRES_HOST_AUTH_METHOD=trust \
		postgres:latest
.PHONY: db-create

# db-destroy destroys the database container.
db-destroy:
	@ echo "--> Destroying database"
	podman rm -f proiect-web-db
.PHONY: db-destroy

# db-start starts the database container.
db-start:
	@ echo "--> Starting database"
	podman start proiect-web-db
	@ sleep 5
.PHONY: db-start

# db-stop stops the database container.
db-stop:
	podman stop proiect-web-db
.PHONY: db-stop
