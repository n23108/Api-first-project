
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
const CheckPassword = async () => {
    const password = document.querySelector(".id").value;

    const strengthView = document.querySelector(".passwordStrength");

    const result = zxcvbn(password);
    const score = result.score;

    strengthView.value = score;
    const responsePost = await fetch('api/passwords', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(password)
    });
    const serverResult = await responsePost.json();

    if (serverResult.isValid == false) {
        alert("סיסמה חלשה מידי, אנה בחרו סיסמה חזקה יותר");
    } else {
        alert(" והסיסמה חזקה מספיק!");
    }
}
