import Header from "./components/Header";
import Footer from "./components/Footer";
import Home from "./components/Home";
import Todos from "./components/Todos";

const appDiv = document.getElementById("app");

export default() => {
    //document.getElementById("app").innerText = "Hello World!";
    setupHeader();
    setupFooter();
    navHome();
    navTodos();
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

        //appDiv.innerHTML = Todos(todos);
    });
}