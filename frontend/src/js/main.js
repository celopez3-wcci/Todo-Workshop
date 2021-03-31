import Header from "./components/Header";
import Footer from "./components/Footer";
import Home from "./components/Home";
import Todos from "./components/Todos";
import Users from "./components/Users";
import User from "./components/User";
import apiAction from "./api/api-actions";


const appDiv = document.getElementById("app");
const todayDate = new Date(Date.now());
const todoAPI = "https://localhost:44393/api/todo/";
const ownerAPI = "https://localhost:44393/api/owner/";

export default () => {
    //document.getElementById("app").innerText = "Hello World!";
    setupHeader();
    setupFooter();
    navHome();
    navTodos();
    navUsers();
    appDiv.innerHTML = Home();
}

function setupHeader() {
    const headerElement = document.querySelector(".header");
    headerElement.innerHTML = Header();
}

function setupFooter() {
    const footerElement = document.querySelector(".footer");
    footerElement.innerText = Footer();
}

function navHome() {
    const homeLink = document.querySelector(".nav_home");
    homeLink.addEventListener('click', function () {
        appDiv.innerHTML = Home();
    });
}

function navTodos() {
    const todosButton = document.querySelector(".nav_todos");
    todosButton.addEventListener('click', function () {

        apiAction.getRequest(todoAPI, values => {
            appDiv.innerHTML = Todos(values);
            fillOwners();
            AddTodo();
            deleteTodoButtons();
        })

        // fetch("https://localhost:44393/api/todo")
        //     .then(response => response.json())
        //     .then(data => appDiv.innerHTML = Todos(data))
        //     .catch(err => console.log(err));
    });
}

function navUsers() {
    const usersButton = document.querySelector(".nav_users");
    usersButton.addEventListener('click', function () {

        apiAction.getRequest("https://localhost:44393/api/owner", values => {
            appDiv.innerHTML = Users(values);
            userNameButton();
        });

        // fetch('https://localhost:44393/api/owner')
        //     .then(response => response.json())
        //     .then(data => {
        //         appDiv.innerHTML = Users(data); 
        //         userNameButton(); 
        //     })
        //     .catch(err => console.log(err));
    });
}

function deleteTodoButtons() {
    const deleteTodoElements = document.querySelectorAll(".fa-trash");
    deleteTodoElements.forEach(element => {
        element.addEventListener('click', function () {
            const todoId = element.id;
            console.log("delete this: " + todoId);

            apiAction.deleteRequest(todoAPI, todoId, data => {
                if (data.indexOf('successfully') > -1) {
                    const liItem = document.getElementById(todoId).parentElement;
                    liItem.remove();
                }
            });

            // fetch(`${todoAPI}${todoId}`, {
            //     method: "DELETE",
            //     headers: {
            //         "Content-Type" : "application/json"
            //     }
            // })
            // .then(response => response.text())
            // .then(data => {
            //     console.log(data);
            //     const liItem = document.getElementById(todoId).parentElement;
            //     liItem.remove();
            //     //appDiv.innerHTML = Todos(todos);
            // })
            // .catch(err => console.log(err));


        });
    })
}

function userNameButton() {
    const userNameElements = document.querySelectorAll(".todo_user");
    userNameElements.forEach(element => {
        element.addEventListener('click', function () {
            const userId = element.id;
            console.log(userId);
            apiAction.getRequest(`https://localhost:44393/api/owner/${userId}`, value => {
                appDiv.innerHTML = User(value);
                userAddTodo();
            });

            // fetch(`https://localhost:44393/api/owner/${userId}`)
            // .then(response => response.json())
            // .then(user => {
            //     appDiv.innerHTML = User(user);
            //     userAddTodo();
            // })
            // .catch(err => console.log(err));
        });
    });

}

function AddTodo(){
    const saveTodoButton = document.getElementById('saveTodoBtn');
    saveTodoButton.addEventListener('click', function(){
        const userId = document.getElementById('owners').value;
        const todoName = document.getElementById('todoName').value;
        let currentDate = todayDate.getFullYear() + "-" + (todayDate.getMonth() + 1) + "-" + todayDate.getDate();
        const requestBody = {
            Name: todoName,
            OwnerId: userId,
            CreatedOn: currentDate,
            DueBy: currentDate
        }

        apiAction.postRequest(todoAPI, requestBody, user => {
            appDiv.innerHTML = User(user);
            userAddTodo();
        })

    });
}

function userAddTodo() {
    const addTodoButton = document.querySelector(".todoAddButton");
    addTodoButton.addEventListener('click', function () {
        const userId = addTodoButton.id;
        const newTodoName = this.parentElement.querySelector(".todoName").value;

        let currentDate = todayDate.getFullYear() + "-" + (todayDate.getMonth() + 1) + "-" + todayDate.getDate();

        const requestBody = {
            Name: newTodoName,
            OwnerId: userId,
            CreatedOn: currentDate,
            DueBy: currentDate
        }

        apiAction.postRequest(todoAPI, requestBody, user => {
            appDiv.innerHTML = User(user);
            userAddTodo();
        })

        // fetch(`https://localhost:44393/api/todo/`, {
        //     method: "POST",
        //     headers: {
        //         "Content-Type" : "application/json"
        //     },
        //     body: JSON.stringify(requestBody)
        // })
        // .then(response => response.json())
        // .then(user => {
        //     console.log(user);
        //     appDiv.innerHTML = User(user);
        //     userAddTodo();
        // })
        // .catch(err => console.log(err));

    });
}

function fillOwners(){
    let dropdown = document.getElementById('owners');
    dropdown.length = 0;

    let defaultOption = document.createElement('option');
    defaultOption.text = 'Select an Owner';
    defaultOption.disabled = 'disabled';

    dropdown.add(defaultOption);
    dropdown.selectedIndex = 0;

    apiAction.getRequest(ownerAPI, users =>{
        let option;
        users.forEach(function(user){
            option = document.createElement('option');
            option.text = user.name;
            option.value = user.id;
            dropdown.add(option);
        })
    })

}