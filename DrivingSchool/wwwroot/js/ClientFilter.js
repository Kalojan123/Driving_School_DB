async function loadClients() {

    // 1. Вземаме стойностите от полетата

    let search = document.getElementById("search").value;

    let drivingInstructor = document.getElementById("drivingInstructor").value;

    let sortOrder = document.getElementById("sortOrder").value;

    // 2. Подготвяме адреса на заявката

    let params = new URLSearchParams({

        search: search,

        drivingInstructor: drivingInstructor,

        sortOrder: sortOrder

    });

    // 3. Изпращаме заявката към контролера

    let response = await fetch(

        "/Client/GetFilteredClients?" + params

    );

    // 4. Преобразуваме JSON отговора в JavaScript обекти

    let clients = await response.json();

    // 5. Изчистваме старите редове от таблицата

    let tbody = document.getElementById("clientsTable");
    tbody.innerHTML = "";

    // 6. Добавяме ред за всеки намерен клиент

    clients.forEach(function (client) {

        let row = document.createElement("tr");

        [client.firstName, client.lastName,

        client.drivingInstructor].forEach(function (value) {

            let cell = document.createElement("td");

            cell.textContent = value ?? "";

            row.appendChild(cell);

        });

        // Колона с линкове за действия

        let actions = document.createElement("td");

        ["Edit", "Details", "Delete"].forEach(function (action, index) {

            if (index > 0) {

                actions.appendChild(document.createTextNode(" | "));

            }

            let link = document.createElement("a");

            link.href = "/Client/" + action + "/" + client.id;

            link.textContent = action;

            actions.appendChild(link);

        });

        row.appendChild(actions);

        tbody.appendChild(row);

    });

}

// Автоматично филтриране

document.getElementById("search")

    .addEventListener("input", loadClients);

document.getElementById("drivingInstructor")

    .addEventListener("input", loadClients);

document.getElementById("sortOrder")

    .addEventListener("change", loadClients);

// Изчистване на филтрите

document.getElementById("clearFilters")

    .addEventListener("click", function () {

        document.getElementById("search").value = "";

        document.getElementById("drivingInstructor").value = "";

        document.getElementById("sortOrder").value = "name_asc";

        loadClients();
    });