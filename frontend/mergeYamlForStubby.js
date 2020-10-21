var fs = require('fs');
var path = require('path');

// Return a list of files of the specified fileTypes in the provided dir,
// with the file path relative to the given dir
// dir: path of the directory you want to search the files for
// fileTypes: array of file types you are search files, ex: ['.txt', '.jpg']
function getFilesFromDir(dir, fileTypes) {
    console.log('Merging all yaml files for stubby.');
    var filesToReturn = [];
    function walkDir(currentPath) {
        var files = fs.readdirSync(currentPath);
        for (var i in files) {
            var curFile = path.join(currentPath, files[i]);
            if (fs.statSync(curFile).isFile() && fileTypes.indexOf(path.extname(curFile)) != -1) {
                filesToReturn.push(curFile.replace(dir, ''));
            } else if (fs.statSync(curFile).isDirectory()) {
                walkDir(curFile);
            }
        }
    }
    walkDir(dir);
    return filesToReturn;
}

let files = getFilesFromDir('./stubs', ['.yaml']);
let output = '';

for (var file in files) {
    if (files[file].indexOf('stubby.yaml') === -1) {
        output += '#######  ' + files[file] + '  #####################################';
        output += '\n\n';
        output += fs.readFileSync(files[file]);
        output += '\n\n';
    }
}

fs.writeFileSync('./stubs/stubby.yaml', output);

console.log('Merging finished.');
