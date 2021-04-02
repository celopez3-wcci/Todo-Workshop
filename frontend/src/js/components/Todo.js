export default function Todo(todo){
    return `
        <h1>Edit Todo Item</h1>
        <section class='todoForm'>
            <input type='text' id='todoName' value='${todo.name}' />
            <input type='hidden' id='ownerId' value='${todo.ownerId}' />
            <input type='hidden' id='todoId' value='${todo.id}' />
            <button id='btnEditTodo'>Save</button>
        </section>
    `
}