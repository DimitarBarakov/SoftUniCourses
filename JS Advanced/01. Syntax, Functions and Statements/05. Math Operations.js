function operations(num1,num2,op){
    let result;
    switch(op){
        case '+': result = num1+num2; break;
        case '-': result = num1-num2; break;
        case '*': result = num1*num2; break;
        case '/': result = num1/num2; break;
        case '%': result = num1%num2; break;
        case '**': result = num1**num2; break;
        default: break;
    }
    return result;
}
console.log(operations(3,5.5,'*'))