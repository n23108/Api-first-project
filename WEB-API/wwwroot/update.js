const obj = JSON.parse(sessionStorage.getItem("currentUser"))

document.querySelector(".userName").value = obj.userName
document.querySelector(".pass").value=    obj.password
document.querySelector(".finame").value = obj.firstName
document.querySelector(".laname").value = obj.lastName
const Update = async () => {
    const userToUpdate = {
        userName: document.querySelector(".userName").value,
        password: document.querySelector(".pass").value,
        firstName: document.querySelector(".finame").value,
        lastName: document.querySelector(".laname").value,
    }
    const userId = obj.id;
    const responsePut = await fetch(`api/User/${userId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(userToUpdate)
    });
    if (responsePut.ok) {
        sessionStorage.setItem("currentUser", JSON.stringify(userToUpdate));
        alert("The user has updated");
    }
    else
        throw new Error("error updating");
}




