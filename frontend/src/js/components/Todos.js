export default function Todos(todos){
    return `
        <h1>Full Todo List</h1>
        <ol>
            ${todos.map(todo =>{
                return `
                    <li>
                        ${todo.name} submitted by ${todo.owner.name} 
                        <i class="far fa-edit" aria-hidden="true" id='${todo.id}'></i>
                        <i class="fa fa-trash" aria-hidden="true" id='${todo.id}'></i>
                    </li>
                `
            }).join('')}
        </ol>

        <section class="todoForm">
            <input type="text" id="todoName" placeholder='Enter the name of this todo' />
            <select id="owners">
            </select>
            <button id="saveTodoBtn">Save Item</button>
        </section>

    `
}