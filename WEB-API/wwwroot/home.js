
const Register = async () => {
    const user = {
        userName: document.querySelector(".uname").value,
        password: document.querySelector(".id").value,
        firstName: document.querySelector(".fname").value,
        lastName: document.querySelector(".lname").value,

    };

    const responsePost = await fetch('api/User', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(user)
    });
    const res= await responsePost.json()
    if (responsePost.ok){
        alert("user succsesfuly added");
        sessionStorage.setItem("currentUser",JSON.stringify(res))
    }
       
    else
        alert("error, try again");

}
const LogIn = async () => {

    const postData = {
        userName: document.querySelector(".luname").value,
        password: document.querySelector(".lid").value,
    }

    const response = await fetch('api/User/Login', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(postData)
    })
    if (response.ok)
        alert("Login successful!");
    else
        alert("Login failed, user not found.")
}
