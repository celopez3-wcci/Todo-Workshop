export default function User(user){
    if(user.todos == null){
        user.todos = [];
    }
    return `
        <h1>${user.name}</h1>
        <ul>
        ${user.todos.map(todo =>{
            return `
                <li>
                   ${todo.name}
                </li>
            `
        }).join('')}
        </ul>

        <section class="user_addtodo">
            <label>Todo Name: </label>
            <input type='text' class="todoName" PlaceHolder="Add a New Item" />
            <br />
            <button class="todoAddButton" id="${user.id}">Add Todo Item</button>
        </section>
    `
}