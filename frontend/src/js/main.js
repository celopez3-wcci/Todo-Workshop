import Header from "./components/Header";
import Footer from "./components/Footer";
import Home from "./components/Home";
import Todos from "./components/Todos";
import Users from "./components/Users";
import User from "./components/User";

const appDiv = document.getElementById("app");
const todayDate = new Date(Date.now());

export default() => {
    //document.getElementById("app").innerText = "Hello World!";
    setupHeader();
    setupFooter();
    navHome();
    navTodos();
    navUsers();
    appDiv.innerHTML = Home();
}

function setupHeader(){
    const headerElement = document.querySelector(".header");
    headerElement.innerHTML = Header();
}

function setupFooter(){
    const footerElement = document.querySelector(".footer");
    footerElement.innerText = Footer();
}

function navHome(){
    const homeLink = document.querySelector(".nav_home");
    homeLink.addEventListener('click', function(){
        appDiv.innerHTML = Home();
    });
}

function navTodos(){
    const todosButton = document.querySelector(".nav_todos");
    todosButton.addEventListener('click', function(){

        fetch("https://localhost:44393/api/todo")
            .then(response => response.json())
            .then(data => appDiv.innerHTML = Todos(data))
            .catch(err => console.log(err));
    });
}

function navUsers(){
    const usersButton = document.querySelector(".nav_users");
    usersButton.addEventListener('click', function(){

        fetch('https://localhost:44393/api/owner')
            .then(response => response.json())
            .then(data => {
                appDiv.innerHTML = Users(data); 
                userNameButton(); 
            })
            .catch(err => console.log(err));
    });
}

function userNameButton(){
    const userNameElements = document.querySelectorAll(".todo_user");
    userNameElements.forEach(element => {
        element.addEventListener('click', function(){
            const userId = element.id;
            fetch(`https://localhost:44393/api/owner/${userId}`)
            .then(response => response.json())
            .then(user => {
                appDiv.innerHTML = User(user);
                userAddTodo();
            })
            .catch(err => console.log(err));
        });
    });

}

function userAddTodo(){
    const addTodoButton = document.querySelector(".todoAddButton");
    addTodoButton.addEventListener('click', function(){
        const userId = addTodoButton.id;
        const newTodoName = this.parentElement.querySelector(".todoName").value;

        let currentDate = todayDate.getFullYear() + "-" + (todayDate.getMonth()+1) + "-" + todayDate.getDate();

        const requestBody = {
            Name: newTodoName,
            OwnerId: userId,
            CreatedOn: currentDate,
            DueBy: currentDate
        }

        fetch(`https://localhost:44393/api/todo/`, {
            method: "POST",
            headers: {
                "Content-Type" : "application/json"
            },
            body: JSON.stringify(requestBody)
        })
        .then(response => response.json())
        .then(user => {
            console.log(user);
            appDiv.innerHTML = User(user);
            userAddTodo();
        })
        .catch(err => console.log(err));

    });
}