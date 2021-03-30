export default function User(user){

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
            <input type='text' class="todoName" PlaceHolder="Add a New Item" />
            <button class="todoAddButton" id="${user.id}">Add Todo Item</button>
        </section>
    `
}