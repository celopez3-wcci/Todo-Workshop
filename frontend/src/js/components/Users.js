export default function Users(users){
    console.log(users);
    return `
        <h1>My User List</h1>
        <ol>
            ${users.map(user =>{
                return `
                    <li>
                        <h4 class="todo_user" id="${user.id}">${user.name} (${user.email})</h4>
                    </li>
                `
            }).join('')}
        </ol>
    `
}