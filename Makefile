DOCKER_COMPOSE_CMD ?= docker compose

help: ## Print help for each target
	$(info =============================)
	$(info Available commands:)
	$(info )
	@grep '^[[:alnum:]_-]*:.* ##' $(MAKEFILE_LIST) \
		| sort | awk 'BEGIN {FS=":.* ## "}; {printf "%-25s %s\n", $$1, $$2};'
	$(info =============================)
.PHONY: help

up: ## Setup containers
	$(DOCKER_COMPOSE_CMD) up --build -d
.PHONY: up

down: ## Stop containers
	$(DOCKER_COMPOSE_CMD) down
.PHONY: down
